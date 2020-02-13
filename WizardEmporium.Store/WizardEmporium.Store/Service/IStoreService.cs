using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Store.Dto;
using WizardEmporium.Store.ServiceObject;

namespace WizardEmporium.Store.Service
{
    public interface IStoreService
    {
        Task<EmptyResponse> AddStockAsync(IEnumerable<MagicItemDto> magicItems);
        Task<BuyItemResponse> BuyItemAsync(int magicItemId, int accountId);
        Task<EmptyResponse> DeleteStockAsync(IEnumerable<int> itemIds);
        Task<SimpleResponse<IEnumerable<MagicItemDto>>> GetAllStockAsync();
        Task<SimpleResponse<IEnumerable<MagicItemOrderDto>>> GetOrdersAsync();
        Task<SimpleResponse<IEnumerable<MagicItemDto>>> GetStockAsync(IEnumerable<int> magicItemIds);
        Task<EmptyResponse> PlaceOrdersAsync(PlaceOrderRequest request);
        Task<ProcessOrderResponse> ProcessOrderAsync(int orderId);
        Task<EmptyResponse> UpdateStockAsync(IEnumerable<MagicItemDto> magicItems);
    }
}