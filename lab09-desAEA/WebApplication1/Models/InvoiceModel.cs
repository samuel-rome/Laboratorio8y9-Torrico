namespace WebApplication1.Models
{
    public class InvoiceModel
    {
        public int Invoice_Id { get; set; }
        public int Customer_Id { get; set; }
        public decimal Total { get; set; }
        public decimal Igv { get; set; }
    }
}
