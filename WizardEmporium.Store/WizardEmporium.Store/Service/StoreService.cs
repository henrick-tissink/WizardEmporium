using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizardEmporium.Common.Constant;
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

        public async Task<SimpleResponse<IEnumerable<MagicItemDto>>> GetAllStockAsync()
        {
            var magicItems = await repo.GetMagicItemsAsync();

            return new SimpleResponse<IEnumerable<MagicItemDto>>
            {
                Value = magicItems
            };
        }

        public async Task<SimpleResponse<IEnumerable<MagicItemDto>>> GetStockAsync(IEnumerable<int> magicItemIds)
        {
            var magicItems = await repo.GetMagicItemsAsync(magicItemIds);

            return new SimpleResponse<IEnumerable<MagicItemDto>>
            {
                Value = magicItems
            };
        }

        public async Task<EmptyResponse> UpdateStockAsync(IEnumerable<MagicItemDto> magicItems)
        {
            await repo.UpdateMagicItemsAsync(magicItems);
            return GlobalResponseCode.None;
        }

        public async Task<EmptyResponse> DeleteStockAsync(IEnumerable<int> itemIds)
        {
            await repo.DeleteMagicItemsAsync(itemIds);
            return GlobalResponseCode.None;
        }

        public async Task<EmptyResponse> AddStockAsync(IEnumerable<MagicItemDto> magicItems)
        {
            await repo.InsertMagicItemsAsync(magicItems);
            return GlobalResponseCode.None;
        }

        public async Task<BuyItemResponse> BuyItemAsync(int magicItemId, int accountId)
        {
            var item = (await repo.GetMagicItemsAsync(new List<int> { magicItemId }))?.FirstOrDefault();

            if (item == null)
                return BuyItemResponseCode.ItemDoesNotExist;

            if (item?.Quantity == 0)
                return BuyItemResponseCode.NoStockAvailable;

            item.Quantity--;

            await repo.UpdateMagicItemsAsync(new List<MagicItemDto> { item });

            // TODO: Allocate item to account...

            return new BuyItemResponse { MagicItem = item };
        }

        public async Task<EmptyResponse> PlaceOrdersAsync(PlaceOrderRequest request)
        {
            await repo.InsertOrderAsync(request.MagicItemId, request.Quantity);
            return GlobalResponseCode.None;
        }

        public async Task<SimpleResponse<IEnumerable<MagicItemOrderDto>>> GetOrdersAsync()
        {
            var orders = await repo.GetOrdersAsync();

            return new SimpleResponse<IEnumerable<MagicItemOrderDto>>
            {
                Value = orders
            };
        }

        public async Task<ProcessOrderResponse> ProcessOrderAsync(int orderId)
        {
            var order = await repo.GetOrderAsync(orderId);
            if (order == null)
                return ProcessOrderResponseCode.OrderNotFound;

            var magicItem = (await repo.GetMagicItemsAsync(new List<int> { order.MagicItemId })).FirstOrDefault();
            magicItem.Quantity += order.Quantity;
            if (magicItem == null)
                return ProcessOrderResponseCode.ItemDoesNotExist;

            await repo.ProcessOrderAsync(orderId, magicItem);

            return ProcessOrderResponseCode.None;
        }
    }
}
