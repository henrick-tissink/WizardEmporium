using WizardEmporium.Common.Constant;

namespace WizardEmporium.Deliveries.Service
{
    public enum DeliveryServiceResponseCode
    {
        Success = GlobalResponseCode.Success,
        DeliveryNotFound = GlobalResponseCode.NotFound,
        DeliveryAlreadyProcessed = GlobalResponseCode.RedundantRequest
    }
}
