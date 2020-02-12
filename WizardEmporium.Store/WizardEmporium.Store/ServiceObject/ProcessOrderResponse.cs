using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;

namespace WizardEmporium.Store.ServiceObject
{
    public enum ProcessOrderResponseCode
    {
        OrderNotFound = GlobalResponseCode.OrderNotFound,
        ItemDoesNotExist = GlobalResponseCode.ItemDoesNotExist,
        None = GlobalResponseCode.None
    }

    public class ProcessOrderResponse : BaseResponse<ProcessOrderResponseCode>
    {
        public ProcessOrderResponse(ProcessOrderResponseCode responseCode = ProcessOrderResponseCode.None) : base(responseCode) { }

        public static implicit operator ProcessOrderResponse(ProcessOrderResponseCode responseCode)
            => new ProcessOrderResponse(responseCode);
    }
}
