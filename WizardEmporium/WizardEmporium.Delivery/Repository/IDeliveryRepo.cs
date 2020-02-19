using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Deliveries.Dto;

namespace WizardEmporium.Deliveries.Repository
{
    public interface IDeliveryRepo
    {
        Task<IEnumerable<DeliveryDto>> GetDeliveriesAsync();
        Task<DeliveryDto> GetDeliveryAsync(int deliveryId);
        Task<int> InsertDeliveryAsnc(int magicItemId, int accountId, int quantity);
        Task UpdateDeliveryAsync(DeliveryDto dto);
    }
}