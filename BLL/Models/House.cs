using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesForSales.Models
{
    [Serializable]
    public class House : Residential
    {
        public House(LegalForm legalForm, Address address, string estateId) : base(estateId, legalForm, address)
        {

        }

        public House() { }

        public override string ToString()
        {
            string estateId = EstateId != null ? ", " + EstateId : null;
            string address = Address != null ? ", " + Address : null;
            string str = "House" + estateId + address;
            return str;
        }
    }
}
