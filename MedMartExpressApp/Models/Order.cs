namespace MedMartExpressApp.Models
{
    public class Order
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string OrderNO { get; set; }
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; }
    }
}
