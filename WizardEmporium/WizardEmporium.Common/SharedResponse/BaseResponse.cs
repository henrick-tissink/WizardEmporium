using System;
using WizardEmporium.Common.Constant;

namespace WizardEmporium.Common.SharedResponse
{
    public abstract class BaseResponse<TResponseCode> where TResponseCode : Enum
    {
        public bool IsSuccessful => GlobalResponseCode == GlobalResponseCode.Success;

        public GlobalResponseCode GlobalResponseCode => (GlobalResponseCode)(object)responseCode;
        protected readonly TResponseCode responseCode;

        public BaseResponse(TResponseCode responseCode) => this.responseCode = responseCode;
    }
}
