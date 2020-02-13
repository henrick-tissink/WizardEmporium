using System.Collections.Generic;
using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Deliveries.Dto;

namespace WizardEmporium.Deliveries.ServiceObject
{
    public enum GetDeliveriesResponseCode
    {
        None = GlobalResponseCode.None
    }

    public class GetDeliveriesResponse : BaseResponse<GetDeliveriesResponseCode>
    {
        public IEnumerable<DeliveryDto> Deliveries { get; set; }

        public GetDeliveriesResponse(GetDeliveriesResponseCode responseCode = GetDeliveriesResponseCode.None) : base(responseCode) { }
        public static implicit operator GetDeliveriesResponse(GetDeliveriesResponseCode responseCode) => new GetDeliveriesResponse(responseCode);
    }
}
