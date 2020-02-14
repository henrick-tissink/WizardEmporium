using System;

namespace WizardEmporium.Common.SharedResponse
{
    public class ValueResponse<TResponseValue, TResponseCode> : BaseResponse<TResponseCode> where TResponseCode : Enum
    {
        public TResponseValue Value { get; set; }

        public ValueResponse(TResponseCode responseCode = default) : base(responseCode) { }

        public static implicit operator ValueResponse<TResponseValue, TResponseCode>(TResponseCode responseCode) =>
            new ValueResponse<TResponseValue, TResponseCode>(responseCode);
    }
}
