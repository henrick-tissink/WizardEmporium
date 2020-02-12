using WizardEmporium.Common.Constant;

namespace WizardEmporium.Common.SharedResponse
{
    public class GeneralResponse : BaseResponse<GlobalResponseCode>
    {
        public GeneralResponse(GlobalResponseCode responseCode = GlobalResponseCode.None) : base(responseCode) { }

        public static implicit operator GeneralResponse(GlobalResponseCode responseCode) => new GeneralResponse(responseCode);
    }
}
