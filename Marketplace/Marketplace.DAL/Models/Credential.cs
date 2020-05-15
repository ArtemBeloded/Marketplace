namespace Marketplace.DAL.Models
{
    public class Credential
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Salt { get; set; }

        public string Password { get; set; }
    }
}
