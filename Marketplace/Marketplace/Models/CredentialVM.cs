using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketplace.Models
{
    public class CredentialVM
    {
        public string Username { get; set; }

        public string Salt { get; set; }

        public string Password { get; set; }
    }
}