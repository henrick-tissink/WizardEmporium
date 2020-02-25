using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Store.Dto;

namespace WizardEmporium.Store.Repository
{
    public interface IStoreRepo
    {
        Task BuyItemAsync(MagicItemDto dto, int orderQuantity);
        Task DeleteMagicItemsAsync(IEnumerable<int> itemIds);
        Task DeleteOrderAsync(int orderId);
        Task<IEnumerable<MagicItemDto>> GetMagicItemsAsync();
        Task<IEnumerable<MagicItemDto>> GetMagicItemsAsync(IEnumerable<int> itemIds);
        Task<MagicItemOrderDto> GetOrderAsync(int orderId);
        Task<IEnumerable<MagicItemOrderDto>> GetOrdersAsync();
        Task InsertMagicItemsAsync(IEnumerable<MagicItemDto> items);
        Task InsertOrderAsync(int magicItem, int quantity);
        Task UpdateMagicItemsAsync(IEnumerable<MagicItemDto> items);
    }
}