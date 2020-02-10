using WizardEmporium.Common.Constant;

namespace WizardEmporium.Common.SharedResponse
{
    public abstract class BaseResponse
    {
        public bool IsSuccessful => GlobalResponseCode == GlobalResponseCode.None;

        public abstract GlobalResponseCode GlobalResponseCode { get; }
    }
}
