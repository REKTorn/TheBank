using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank
{
    class Customer
    {
        public string Name { get; set; }
        public float Balance { get; set; }
        public string ShowCustomer { get { return Name; } }
    }
}
