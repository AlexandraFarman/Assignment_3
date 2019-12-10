using HomesForSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class FindEstateDto
    {
        public string EstateId { get; set; }
        public LegalForm LegalForm { get; set; }
        public Estate Type { get; set; }
        public Estate Category { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public Countries Country { get; set; }
    }
}
