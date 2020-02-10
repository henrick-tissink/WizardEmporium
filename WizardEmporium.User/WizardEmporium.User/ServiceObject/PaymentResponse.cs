namespace WizardEmporium.User.ServiceObject
{
    public class PaymentResponse
    {
        public int AccountId { get; set; }
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingBalance { get; set; }
        public string Reference { get; set; }
    }
}
