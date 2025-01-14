using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.UML1
{
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public string Country { get; set; }

        private bool Validate()
        {
            // Implementation
            return true;
        }

        public string OutputAsLabel()
        {
            // Implementation
            return $"{Street}, {City}, {State} {PostalCode}, {Country}";
        }
    }
}
