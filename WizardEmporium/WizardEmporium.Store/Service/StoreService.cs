using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Store.Dto;
using WizardEmporium.Store.Repository;
using WizardEmporium.Store.ServiceObject;

namespace WizardEmporium.Store.Service
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepo repo;

        public StoreService(IStoreRepo repo)
        {
            this.repo = repo;
        }

        public async Task<ValueResponse<IEnumerable<MagicItemDto>, StoreServiceResponseCode>> GetAllStockAsync()
        {
            var magicItems = await repo.GetMagicItemsAsync();

            return new ValueResponse<IEnumerable<MagicItemDto>, StoreServiceResponseCode>
            {
                Value = magicItems
            };
        }

        public async Task<ValueResponse<IEnumerable<MagicItemDto>, StoreServiceResponseCode>> GetStockAsync(IEnumerable<int> magicItemIds)
        {
            var magicItems = await repo.GetMagicItemsAsync(magicItemIds);

            return new ValueResponse<IEnumerable<MagicItemDto>, StoreServiceResponseCode>
            {
                Value = magicItems
            };
        }

        public async Task<EmptyResponse<StoreServiceResponseCode>> UpdateStockAsync(IEnumerable<MagicItemDto> magicItems)
        {
            await repo.UpdateMagicItemsAsync(magicItems);
            return StoreServiceResponseCode.Success;
        }

        public async Task<EmptyResponse<StoreServiceResponseCode>> DeleteStockAsync(IEnumerable<int> itemIds)
        {
            await repo.DeleteMagicItemsAsync(itemIds);
            return StoreServiceResponseCode.Success;
        }

        public async Task<EmptyResponse<StoreServiceResponseCode>> AddStockAsync(IEnumerable<MagicItemDto> magicItems)
        {
            await repo.InsertMagicItemsAsync(magicItems);
            return StoreServiceResponseCode.Success;
        }

        public async Task<BuyItemResponse> BuyItemAsync(int magicItemId, int accountId)
        {
            var item = (await repo.GetMagicItemsAsync(new List<int> { magicItemId }))?.FirstOrDefault();

            if (item == null)
                return StoreServiceResponseCode.ItemDoesNotExist;

            if (item?.Quantity == 0)
                return StoreServiceResponseCode.NoStockAvailable;

            item.Quantity--;

            await repo.UpdateMagicItemsAsync(new List<MagicItemDto> { item });

            // TODO: Allocate item to account...

            return new BuyItemResponse { MagicItem = item };
        }

        public async Task<EmptyResponse<StoreServiceResponseCode>> PlaceOrdersAsync(PlaceOrderRequest request)
        {
            await repo.InsertOrderAsync(request.MagicItemId, request.Quantity);
            return StoreServiceResponseCode.Success;
        }

        public async Task<ValueResponse<IEnumerable<MagicItemOrderDto>, StoreServiceResponseCode>> GetOrdersAsync()
        {
            var orders = await repo.GetOrdersAsync();

            return new ValueResponse<IEnumerable<MagicItemOrderDto>, StoreServiceResponseCode>
            {
                Value = orders
            };
        }

        public async Task<EmptyResponse<StoreServiceResponseCode>> ProcessOrderAsync(int orderId)
        {
            var order = await repo.GetOrderAsync(orderId);
            if (order == null)
                return StoreServiceResponseCode.OrderNotFound;

            var magicItem = (await repo.GetMagicItemsAsync(new List<int> { order.MagicItemId })).FirstOrDefault();
            magicItem.Quantity += order.Quantity;
            if (magicItem == null)
                return StoreServiceResponseCode.ItemDoesNotExist;

            await repo.ProcessOrderAsync(orderId, magicItem);

            return StoreServiceResponseCode.Success;
        }
    }
}
