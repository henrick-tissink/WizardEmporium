using WizardEmporium.Common.Constant;

namespace WizardEmporium.Store.Service
{
    public enum StoreServiceResponseCode
    {
        Success = GlobalResponseCode.Success,
        NoStockAvailable = GlobalResponseCode.InvalidRequest,
        ItemDoesNotExist = GlobalResponseCode.NotFound,
        OrderNotFound = GlobalResponseCode.NotFound,
        OrderDoesNotExist = GlobalResponseCode.NotFound
    }
}
