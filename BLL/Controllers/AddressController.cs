using HomesForSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public class AddressController : IAddressController
    {
        public bool AddAddress(Address address)
        {
            return true;
        }

        public bool UpdateAddress(Address address)
        {
            return true;
        }

        public bool DeleteAddress(Address address)
        {
            return true;
        }
        public bool SearchAddress(Address address)
        {
            return true;
        }

        public List<Address> GetAllAddresses()
        {
            List<Address> addresses = new List<Address>();
            addresses.Add(new Address(1, "Exempelgata 1", "12345", "Malmö", Countries.Angola));
            addresses.Add(new Address(2, "Exempelgata 2", "444444", "Malmö", Countries.Armenia));
            return addresses;
        }
    }
}
