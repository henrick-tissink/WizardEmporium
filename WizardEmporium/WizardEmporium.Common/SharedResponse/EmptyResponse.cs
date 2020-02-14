using System;

namespace WizardEmporium.Common.SharedResponse
{
    public class EmptyResponse<TResponseCode> : BaseResponse<TResponseCode> where TResponseCode : Enum
    {
        public EmptyResponse(TResponseCode responseCode) : base(responseCode) { }

        public static implicit operator EmptyResponse<TResponseCode>(TResponseCode responseCode) =>
            new EmptyResponse<TResponseCode>(responseCode);
    }
}
