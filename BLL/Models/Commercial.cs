using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesForSales.Models
{
    public class Commercial : Estate
    {
        public Commercial(string estateId, LegalForm legalForm, Address address) : base(estateId, legalForm, address)
        {

        }

        public Commercial() { }

        public override string ToString()
        {
            return "Commersial";
        }
    }
}
