using System.Collections.Generic;
using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Store.Dto;

namespace WizardEmporium.Store.ServiceObject
{
    public class GetMagicItemsResponse : BaseResponse<GlobalResponseCode>
    {
        public IEnumerable<MagicItemDto> MagicItems { get; set; }

        public GetMagicItemsResponse(GlobalResponseCode responseCode = GlobalResponseCode.None) : base(responseCode) { } 

        public static implicit operator GetMagicItemsResponse(GlobalResponseCode responseCode)
            => new GetMagicItemsResponse(responseCode);
    }
}
