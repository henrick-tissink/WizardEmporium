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

        public async Task<ValueResponse<IEnumerable<DeliveryDto>, DeliveryServiceResponseCode>> GetDeliveriesAsync()
        {
            var deliveries = await repo.GetDeliveriesAsync();

            return new ValueResponse<IEnumerable<DeliveryDto>, DeliveryServiceResponseCode>
            {
                Value = deliveries
            };
        }

        public async Task<ValueResponse<DeliveryDto, DeliveryServiceResponseCode>> GetDeliveryAsync(int deliveryId)
        {
            var delivery = await repo.GetDeliveryAsync(deliveryId);

            return new ValueResponse<DeliveryDto, DeliveryServiceResponseCode>
            {
                Value = delivery
            };
        }

        public async Task<EmptyResponse<DeliveryServiceResponseCode>> ScheduleDelivery(ScheduleDeliveryRequest request)
        {
            await repo.InsertDeliveryAsnc(request.MagicItemId, request.AccountId, request.Quantity);
            return DeliveryServiceResponseCode.Success;
        }

        public async Task<EmptyResponse<DeliveryServiceResponseCode>> CompleteDeliveryAsync(int deliveryId)
        {
            var delivery = await repo.GetDeliveryAsync(deliveryId);
            if (delivery == null)
                return DeliveryServiceResponseCode.DeliveryNotFound;

            if (delivery.Completed)
                return DeliveryServiceResponseCode.DeliveryAlreadyProcessed;

            delivery.Completed = true;
            await repo.UpdateDeliveryAsync(delivery);

            return DeliveryServiceResponseCode.Success;
        }
    }
}
