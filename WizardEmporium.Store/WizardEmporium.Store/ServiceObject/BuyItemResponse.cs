using WizardEmporium.Common.Constant;
using WizardEmporium.Common.SharedResponse;
using WizardEmporium.Store.Dto;

namespace WizardEmporium.Store.ServiceObject
{
    public enum BuyItemResponseCode
    {
        NoStockAvailable = GlobalResponseCode.NoStockAvailable,
        ItemDoesNotExist = GlobalResponseCode.ItemDoesNotExist,
        None = GlobalResponseCode.None
    }

    public class BuyItemResponse : BaseResponse<BuyItemResponseCode>
    {
        public MagicItemDto MagicItem { get; set; }

        public BuyItemResponse(BuyItemResponseCode responseCode = BuyItemResponseCode.None) : base(responseCode) { }

        public static implicit operator BuyItemResponse(BuyItemResponseCode responseCode)
            => new BuyItemResponse(responseCode);
    }
}
