using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
