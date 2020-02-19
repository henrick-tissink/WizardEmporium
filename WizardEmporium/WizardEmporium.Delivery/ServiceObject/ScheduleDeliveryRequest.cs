using System.ComponentModel.DataAnnotations;

namespace WizardEmporium.Deliveries.ServiceObject
{
    public class ScheduleDeliveryRequest
    {
        [Required]
        public int MagicItemId { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
