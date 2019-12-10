using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesForSales.Models
{
    public class Shop : Commercial
    {
        public Shop(LegalForm legalForm, Address address, string estateId) : base(estateId, legalForm, address)
        {

        }

        public Shop() { }

        public override string ToString()
        {
            string estateId = EstateId != null ? ", " + EstateId : null;
            string address = Address != null ? ", " + Address : null;
            string str = "Shop" + estateId + address;
            return str;
        }
    }
}
