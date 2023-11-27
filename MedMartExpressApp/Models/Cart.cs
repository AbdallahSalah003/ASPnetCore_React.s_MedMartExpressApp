namespace MedMartExpressApp.Models
{
    public class Cart
    { 
        public int id { get; set; }
        public int userId { get; set; }
        public int MedId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public int quantity { get; set; }
        public decimal TotPrice { get; set; }
    }
}
