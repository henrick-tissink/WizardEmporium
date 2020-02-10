using WizardEmporium.Common.Constant;

namespace WizardEmporium.Common.SharedResponse
{
    public class GeneralResponse : BaseResponse
    {
        public override GlobalResponseCode GlobalResponseCode => ResponseCode;

        public GeneralResponse(GlobalResponseCode responseCode)
        {
            ResponseCode = responseCode;
        }

        private GlobalResponseCode ResponseCode { get; }

        public static implicit operator GeneralResponse(GlobalResponseCode responseCode) => new GeneralResponse(responseCode);
    }
}
