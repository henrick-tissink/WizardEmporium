using System.Collections.Generic;
using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Store.Dto;

namespace WizardEmporium.Store.ServiceObject
{
    public enum GetOrdersResponseCode
    {
        None = GlobalResponseCode.None
    }

    public class GetOrdersResponse : BaseResponse<GetOrdersResponseCode>
    {
        public IEnumerable<MagicItemOrderDto> OutstandingOrders { get; set; }

        public GetOrdersResponse(GetOrdersResponseCode responseCode = GetOrdersResponseCode.None) : base(responseCode) { }

        public static implicit operator GetOrdersResponse(GetOrdersResponseCode responseCode)
            => new GetOrdersResponse(responseCode);
    }
}
