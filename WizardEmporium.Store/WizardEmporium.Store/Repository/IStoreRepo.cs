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
        Task InsertMagicItemsAsync(IEnumerable<MagicItemDto> items);
        Task InsertOrderAsync(MagicItemOrderDto dto);
        Task UpdateMagicItemsAsync(IEnumerable<MagicItemDto> items);
    }
}