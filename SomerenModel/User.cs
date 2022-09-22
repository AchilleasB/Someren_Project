using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class User
    {
        public string Username { get; set; }
        public string Digest { get; set; }
        public string Salt { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Role { get; set; }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }

    }
}
