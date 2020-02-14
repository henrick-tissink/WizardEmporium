using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Deliveries.Dto;
using WizardEmporium.Deliveries.ServiceObject;

namespace WizardEmporium.Deliveries.Service
{
    public interface IDeliveryService
    {
        Task<EmptyResponse<DeliveryServiceResponseCode>> CompleteDeliveryAsync(int deliveryId);
        Task<ValueResponse<IEnumerable<DeliveryDto>, DeliveryServiceResponseCode>> GetDeliveriesAsync();
        Task<ValueResponse<DeliveryDto, DeliveryServiceResponseCode>> GetDeliveryAsync(int deliveryId);
        Task<EmptyResponse<DeliveryServiceResponseCode>> ScheduleDelivery(ScheduleDeliveryRequest request);
    }
}