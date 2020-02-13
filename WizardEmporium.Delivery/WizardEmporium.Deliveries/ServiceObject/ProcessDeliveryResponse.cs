using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;

namespace WizardEmporium.Deliveries.ServiceObject
{
    public enum ProcessDeliveryResponseCode
    {
        DeliveryNotFound = GlobalResponseCode.ResourceNotFound,
        DeliveryAlreadyProcessed = GlobalResponseCode.ActionAlreadyCompleted,
        Success = GlobalResponseCode.None
    }

    public class ProcessDeliveryResponse : BaseResponse<ProcessDeliveryResponseCode>
    {
        public ProcessDeliveryResponse(ProcessDeliveryResponseCode responseCode = ProcessDeliveryResponseCode.Success) : base(responseCode) { }
        public static implicit operator ProcessDeliveryResponse(ProcessDeliveryResponseCode responseCode) => new ProcessDeliveryResponse(responseCode);
    }
}
