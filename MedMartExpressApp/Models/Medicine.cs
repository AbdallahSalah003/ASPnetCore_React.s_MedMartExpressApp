namespace MedMartExpressApp.Models
{
    public class Medicine
    {
        public int id { get; set; }
        public string Medname { get; set; }
        public string Manufacutrur { get; set; }
        public decimal unitPrice { get; set; }
        public decimal Discount { get; set; }
        public int quantity { get; set; }
        public DateTime Expdate { get; set; }
        public string ImageUrl { get; set; }
        public int status { get; set; }
    }
}
