namespace Marketplace.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int UserId { get; set; }

        public User Buyer { get; set; }
    }
}
