using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Deliveries.Dto;
using WizardEmporium.Deliveries.ServiceObject;

namespace WizardEmporium.Deliveries.Service
{
    public interface IDeliveryService
    {
        Task<ProcessDeliveryResponse> CompleteDeliveryAsync(int deliveryId);
        Task<SimpleResponse<IEnumerable<DeliveryDto>>> GetDeliveriesAsync();
        Task<SimpleResponse<DeliveryDto>> GetDeliveryAsync(int deliveryId);
        Task<EmptyResponse> ScheduleDelivery(ScheduleDeliveryRequest request);
    }
}