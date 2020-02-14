using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Store.Dto;
using WizardEmporium.Store.Service;

namespace WizardEmporium.Store.ServiceObject
{
    public class BuyItemResponse : BaseResponse<StoreServiceResponseCode>
    {
        public MagicItemDto MagicItem { get; set; }

        public BuyItemResponse(StoreServiceResponseCode responseCode = default) : base(responseCode) { }

        public static implicit operator BuyItemResponse(StoreServiceResponseCode responseCode)
            => new BuyItemResponse(responseCode);
    }
}
