using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.UML3
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int Payment { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void Update() { }
    }
}
