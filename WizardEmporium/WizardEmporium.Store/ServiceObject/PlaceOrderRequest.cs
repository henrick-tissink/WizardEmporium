using System.ComponentModel.DataAnnotations;

namespace WizardEmporium.Store.ServiceObject
{
    public class PlaceOrderRequest
    {
        [Required]
        public int MagicItemId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
