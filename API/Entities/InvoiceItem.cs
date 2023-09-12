namespace API.Entities
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal PriceOfService { get; set; }
        public decimal PriceOfServiceInEuros { get; set; }
        public decimal Discount { get; set; }
        public decimal Tax { get; set; }
        public decimal TotalPrice { get; set; }
        public int InvoiceHeaderId { get; set; }
        public InvoiceHeader InvoiceHeader { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}