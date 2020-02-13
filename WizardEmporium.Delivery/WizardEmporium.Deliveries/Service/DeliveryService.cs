using System.Collections.Generic;
using System.Threading.Tasks;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Deliveries.Dto;
using WizardEmporium.Deliveries.Repository;
using WizardEmporium.Deliveries.ServiceObject;

namespace WizardEmporium.Deliveries.Service
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepo repo;

        public DeliveryService(IDeliveryRepo repo)
        {
            this.repo = repo;
        }

        public async Task<SimpleResponse<IEnumerable<DeliveryDto>>> GetDeliveriesAsync()
        {
            var deliveries = await repo.GetDeliveriesAsync();

            return new SimpleResponse<IEnumerable<DeliveryDto>>
            {
                Value = deliveries
            };
        }

        public async Task<SimpleResponse<DeliveryDto>> GetDeliveryAsync(int deliveryId)
        {
            var delivery = await repo.GetDeliveryAsync(deliveryId);

            return new SimpleResponse<DeliveryDto>
            {
                Value = delivery
            };
        }

        public async Task<EmptyResponse> ScheduleDelivery(ScheduleDeliveryRequest request)
        {
            await repo.InsertDeliveryAsnc(request.MagicItemId, request.AccountId, request.Quantity);
            return EmptyResponseCode.Success;
        }

        public async Task<ProcessDeliveryResponse> CompleteDeliveryAsync(int deliveryId)
        {
            var delivery = await repo.GetDeliveryAsync(deliveryId);
            if (delivery == null)
                return ProcessDeliveryResponseCode.DeliveryNotFound;

            if (delivery.Completed)
                return ProcessDeliveryResponseCode.DeliveryAlreadyProcessed;

            delivery.Completed = true;
            await repo.UpdateDeliveryAsync(delivery);

            return ProcessDeliveryResponseCode.Success;
        }
    }
}
