using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesForSales.Models
{
    [Serializable]
    public class Townhouse : Residential
    {
        public Townhouse(LegalForm legalForm, Address address, string estateId) : base(estateId, legalForm, address)
        {

        }

        public Townhouse() { }

        public override string ToString()
        {
            string estateId = EstateId != null ? ", " + EstateId : null;
            string address = Address != null ? ", " + Address : null;
            string str = "Townhouse" + estateId + address;
            return str;
        }
    }
}
