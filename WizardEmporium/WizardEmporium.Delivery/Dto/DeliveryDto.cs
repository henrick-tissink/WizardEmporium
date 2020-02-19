namespace WizardEmporium.Deliveries.Dto
{
    public class DeliveryDto
    {
        public int DeliveryId { get; set; }
        public int MagicItemId { get; set; }
        public int AccountId { get; set; }
        public int Quantity { get; set; }
        public bool Completed { get; set; }
    }
}
