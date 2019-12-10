using HomesForSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public interface IAddressController
    {
        List<Address> GetAllAddresses();
        bool AddAddress(Address address);
        bool UpdateAddress(Address address);
        bool DeleteAddress(Address address);
        bool SearchAddress(Address address);
    }
}
