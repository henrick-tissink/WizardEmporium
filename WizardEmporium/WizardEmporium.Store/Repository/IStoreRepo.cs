using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Store.Dto;

namespace WizardEmporium.Store.Repository
{
    public interface IStoreRepo
    {
        Task DeleteMagicItemsAsync(IEnumerable<int> itemIds);
        Task DeleteOrderAsync(int orderId);
        Task<IEnumerable<MagicItemDto>> GetMagicItemsAsync();
        Task<IEnumerable<MagicItemDto>> GetMagicItemsAsync(IEnumerable<int> itemIds);
        Task InsertMagicItemsAsync(IEnumerable<MagicItemDto> items);
        Task InsertOrderAsync(int magicItemId, int quantity);
        Task<IEnumerable<MagicItemOrderDto>> GetOrdersAsync();
        Task<MagicItemOrderDto> GetOrderAsync(int orderId);
        Task UpdateMagicItemsAsync(IEnumerable<MagicItemDto> items);
        Task ProcessOrderAsync(int orderId, MagicItemDto dto);
    }
}