using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomesForSales.Models
{
    [Serializable]
    public class Address
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public Countries Country { get; set; }

        public Address(string id, string street, string zipCode, string city, Countries country)
        {
            Id = id;
            Street = street;
            ZipCode = zipCode;
            City = city;
            Country = country;
        }

        public Address(string street, string zipCode, string city, Countries country)
        {
            Street = street;
            ZipCode = zipCode;
            City = city;
            Country = country;
        }

        public override string ToString()
        {
            return $"{Street}, {ZipCode}, {City}, {Country}";
        }
    }
}
