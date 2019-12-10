using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesForSales.Models
{
    public class Warehouse : Commercial
    {
        public Warehouse(LegalForm legalForm, Address address, string estateId) : base(estateId, legalForm, address)
        {

        }

        public Warehouse() { }

        public override string ToString()
        {
            string estateId = EstateId != null ? ", " + EstateId : null;
            string address = Address != null ? ", " + Address : null;
            string str = "Warehouse" + estateId + address;
            return str;
        }
    }
}
