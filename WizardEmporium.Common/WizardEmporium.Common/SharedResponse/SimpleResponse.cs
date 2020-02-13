using WizardEmporium.Common.Constant;

namespace WizardEmporium.Common.SharedResponse
{
    public class SimpleResponse<TResponseValue> : BaseResponse<GlobalResponseCode>
    {
        public TResponseValue Value { get; set; }

        public SimpleResponse(GlobalResponseCode responseCode = GlobalResponseCode.None) : base(responseCode) { }

        public static implicit operator SimpleResponse<TResponseValue>(GlobalResponseCode responseCode) =>
            new SimpleResponse<TResponseValue>(responseCode);
    }
}
