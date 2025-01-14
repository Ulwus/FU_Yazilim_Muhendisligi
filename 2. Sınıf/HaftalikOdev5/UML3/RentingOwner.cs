using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.UML3
{
    public class RentingOwner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string ContactNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool VerifyAccount()
        {
            // Implementation
            return true;
        }
    }
}
