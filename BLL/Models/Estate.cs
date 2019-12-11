using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesForSales.Models
{
    [Serializable]
    public abstract class Estate
    {
        public string EstateId { get; set; }
        public LegalForm LegalForm { get; set; }
        public Address Address { get; set; }

        public Estate(string estateId, LegalForm legalForm, Address address)
        {
            EstateId = estateId;
            LegalForm = legalForm;
            Address = address;

        }

        public Estate() { }
    }
}
