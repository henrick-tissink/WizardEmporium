using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Store.Service;

namespace WizardEmporium.Store.ServiceObject
{
    public class ProcessOrderResponse : BaseResponse<StoreServiceResponseCode>
    {
        public ProcessOrderResponse(StoreServiceResponseCode responseCode = default) : base(responseCode) { }

        public static implicit operator ProcessOrderResponse(StoreServiceResponseCode responseCode)
            => new ProcessOrderResponse(responseCode);
    }
}
