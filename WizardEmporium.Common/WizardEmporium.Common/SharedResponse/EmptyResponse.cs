using WizardEmporium.Common.Constant;

namespace WizardEmporium.Common.SharedResponse
{
    public enum EmptyResponseCode
    {
        Success = GlobalResponseCode.None
    }

    public class EmptyResponse : BaseResponse<EmptyResponseCode>
    {
        public EmptyResponse(EmptyResponseCode responseCode = EmptyResponseCode.Success) : base(responseCode) { }

        public static implicit operator EmptyResponse(EmptyResponseCode responseCode) =>
            new EmptyResponse(responseCode);
    }
}
