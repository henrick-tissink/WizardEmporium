using System.ComponentModel.DataAnnotations;

namespace WizardEmporium.User.ServiceObject
{
    public class PaymentRequest
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public string Reference { get; set; }
    }
}
