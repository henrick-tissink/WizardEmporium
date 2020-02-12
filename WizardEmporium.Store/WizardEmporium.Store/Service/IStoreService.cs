using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Store.Dto;
using WizardEmporium.Store.ServiceObject;

namespace WizardEmporium.Store.Service
{
    public interface IStoreService
    {
        Task<GeneralResponse> AddStockAsync(IEnumerable<MagicItemDto> magicItems);
        Task<BuyItemResponse> BuyItemAsync(int magicItemId, int userId);
        Task<GeneralResponse> DeleteStockAsync(IEnumerable<int> itemIds);
        Task<GetMagicItemsResponse> GetAllStockAsync();
        Task<GetMagicItemsResponse> GetStockAsync(IEnumerable<int> magicItemIds);
        Task<GeneralResponse> PlaceOrdersAsync(PlaceOrderRequest request);
        Task<ProcessOrderResponse> ProcessOrderAsync(int orderId);
        Task<GeneralResponse> UpdateStockAsync(IEnumerable<MagicItemDto> magicItems);
    }
}