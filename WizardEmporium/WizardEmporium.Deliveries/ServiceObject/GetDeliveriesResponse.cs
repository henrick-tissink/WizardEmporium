using System.Collections.Generic;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Deliveries.Dto;
using WizardEmporium.Deliveries.Service;

namespace WizardEmporium.Deliveries.ServiceObject
{
    public class GetDeliveriesResponse : BaseResponse<DeliveryServiceResponseCode>
    {
        public IEnumerable<DeliveryDto> Deliveries { get; set; }

        public GetDeliveriesResponse(DeliveryServiceResponseCode responseCode = default) : base(responseCode) { }
        public static implicit operator GetDeliveriesResponse(DeliveryServiceResponseCode responseCode) => new GetDeliveriesResponse(responseCode);
    }
}
