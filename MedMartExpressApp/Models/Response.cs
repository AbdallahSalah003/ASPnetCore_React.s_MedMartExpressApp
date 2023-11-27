namespace MedMartExpressApp.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<User> listOfUsers { get; set; }
        public User user { get; set; }
        public List<Medicine> listOfMedicines { get; set; }
        public Medicine medicine { get; set; }
        public List<Cart> listOfCarts { get; set; }
        public Cart cart { get; set; }
        public List<Order> listOfOrders { get; set; }
        public Order order { get; set; }
        public List<OrderItem> listOfOrderItems { get; set; }
        public OrderItem orderItem { get; set; }

    }
}
