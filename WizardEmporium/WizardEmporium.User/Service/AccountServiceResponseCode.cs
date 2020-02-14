using WizardEmporium.Common.Constant;

namespace WizardEmporium.User.Service
{
    public enum AccountServiceResponseCode
    {

        Success = GlobalResponseCode.Success,
        AccountAlreadySuspended = GlobalResponseCode.RedundantRequest,
        AccountAlreadyUnsuspended = GlobalResponseCode.RedundantRequest,
        AccountAlreadyExists = GlobalResponseCode.RedundantRequest,
        AccountDoesNotExist = GlobalResponseCode.NotFound,
        InvalidPasswordOrUsername = GlobalResponseCode.InvalidRequest
    }
}
