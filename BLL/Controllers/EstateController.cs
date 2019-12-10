using BLL.Models;
using HomesForSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public class EstateController : IEstateController
    {
        public List<Estate> GetEstateTypes()
        {
            // Examples. Should be fetched from database.
            var estateTypes = new List<Estate>();
            estateTypes.Add(new Apartment());
            estateTypes.Add(new House());
            estateTypes.Add(new Shop());
            estateTypes.Add(new Townhouse());
            estateTypes.Add(new Warehouse());
            estateTypes.Add(new Villa());

            return estateTypes;
        }

        public List<Estate> GetEstateCategories()
        {
            // Examples. Should be fetched from database.
            var estateCategories = new List<Estate>();
            estateCategories.Add(new Commercial());
            estateCategories.Add(new Residential());

            return estateCategories;
        }

        public List<Estate> GetAllEstates()
        {
            // Examples. Should be fetched from database.
            var estates = new List<Estate>();
            estates.Add(new Apartment(
                LegalForm.Ownership,
                new Address(1, "Exempelgata 1", "12345", "Malmö", Countries.Saint_Lucia),
                "1"));
            estates.Add(new House(
                LegalForm.Ownership,
                new Address(2, "Exempelgata 2", "54321", "Malmå", Countries.San_Marino),
                "2"));

            return estates;
        }

        public bool AddEstate(Estate estate)
        {
            return true;
        }

        public bool UpdateEstate(Estate estate)
        {
            var estateType = estate.GetType();
            return true;
        }

        public bool DeleteEstate(Estate estate)
        {
            return true;
        }

        public List<Estate> SearchEstate(FindEstateDto estate)
        {
            // Examples. Should be fetched from database.
            var estates = new List<Estate>();
            estates.Add(new Apartment(
                LegalForm.Ownership,
                new Address(1, "Exempelgata 1", "12345", "Malmö", Countries.Saint_Lucia),
                "1"));
            estates.Add(new House(
                LegalForm.Ownership,
                new Address(2, "Exempelgata 2", "54321", "Malmå", Countries.San_Marino),
                "2"));

            return estates;
        }
    }
}
