using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Store.Dto;
using WizardEmporium.Store.ServiceObject;

namespace WizardEmporium.Store.Service
{
    public interface IStoreService
    {
        Task<EmptyResponse<StoreServiceResponseCode>> AddStockAsync(IEnumerable<MagicItemDto> magicItems);
        Task<EmptyResponse<StoreServiceResponseCode>> BuyItemAsync(int magicItemId, int accountId);
        Task<EmptyResponse<StoreServiceResponseCode>> DeleteStockAsync(IEnumerable<int> itemIds);
        Task<ValueResponse<IEnumerable<MagicItemDto>, StoreServiceResponseCode>> GetAllStockAsync();
        Task<ValueResponse<IEnumerable<MagicItemOrderDto>, StoreServiceResponseCode>> GetOrdersAsync();
        Task<ValueResponse<IEnumerable<MagicItemDto>, StoreServiceResponseCode>> GetStockAsync(IEnumerable<int> magicItemIds);
        Task<EmptyResponse<StoreServiceResponseCode>> PlaceOrdersAsync(PlaceOrderRequest request);
        Task<EmptyResponse<StoreServiceResponseCode>> ProcessOrderAsync(int orderId);
        Task<EmptyResponse<StoreServiceResponseCode>> UpdateStockAsync(IEnumerable<MagicItemDto> magicItems);
    }
}