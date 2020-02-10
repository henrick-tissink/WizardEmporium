using WizardEmporium.Common.Constant;

namespace WizardEmporium.Common.SharedResponse
{
    public class ErrorResponse
    {
        public ErrorResponse(GlobalResponseCode errorCode)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorCode.ToString();
        }

        public GlobalResponseCode ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
