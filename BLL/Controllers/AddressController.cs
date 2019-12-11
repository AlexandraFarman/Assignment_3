using BLL.DAL;
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
        private readonly AddressManager _addressManager;

        public AddressController(AddressManager am)
        {
            _addressManager = am;
        }

        public bool AddAddress(Address address)
        {
            return _addressManager.Add(address);
        }

        public bool UpdateAddress(Address address)
        {
            int index = SearchAddressById(address.Id);
            if (index < 0)
                return false;

            Address addressCopy = CopyAddress(address);
            return _addressManager.ChangeAt(addressCopy, index);
        }

        public bool DeleteAddress(Address address)
        {
            int index = SearchAddressById(address.Id);
            if (index < 0)
                return false;

            return _addressManager.DeleteAt(index);
        }

        public List<Address> GetAllAddresses()
        {
            return _addressManager.GetAll();
        }

        private int SearchAddressById(string addressId)
        {
            return _addressManager.GetAll().FindIndex(e => e.Id == addressId);
        }

        private Address CopyAddress(Address address)
        {
            Address addressCopy = new Address(address.Id, address.Street, address.ZipCode, address.City, address.Country);
            return addressCopy;
        }
    }
}
