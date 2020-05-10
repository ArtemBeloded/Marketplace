namespace Marketplace.Models
{
    public class CredentialVM
    {
        public string Username { get; set; }

        public string Salt { get; set; }

        public string Password { get; set; }
    }
}