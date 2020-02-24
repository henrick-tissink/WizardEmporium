using WizardEmporium.Common.Constant;

namespace WizardEmporium.Common.SharedResponse
{
    public class ErrorResponse
    {
        public ErrorResponse(GlobalResponseCode errorCode)
        {
            ErrorCode = errorCode;
        }

        public GlobalResponseCode ErrorCode { get; set; }
        public string ErrorMessage => ErrorCode.ToString();
    }
}
