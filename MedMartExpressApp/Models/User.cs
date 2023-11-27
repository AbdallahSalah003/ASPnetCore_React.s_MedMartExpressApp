namespace MedMartExpressApp.Models
{
    public class User
    {
        public string id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        public double Fund { get; set; }
        public string Type { get; set; }
        public int status { get; set; }
        public DateTime createdon { get; set; }
    }
}
