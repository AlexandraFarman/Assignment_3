using BLL.DAL;
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
        private readonly EstateManager _estateManager;

        public EstateController(EstateManager em)
        {
            _estateManager = em;
        }

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
            return _estateManager.GetAll();
        }

        public bool AddEstate(Estate estate)
        {
            Estate estateCopy = CopyEstate(estate);
            Clear(estate);
            return _estateManager.Add(estateCopy);
        }

        public bool UpdateEstate(Estate estate)
        {
            int index = SearchEstateById(estate.EstateId);
            if (index < 0)
                return false;

            Estate estateCopy = CopyEstate(estate);
            return _estateManager.ChangeAt(estateCopy, index);
        }

        public bool DeleteEstate(Estate estate)
        {
            int index = SearchEstateById(estate.EstateId);
            if (index < 0)
                return false;

            return _estateManager.DeleteAt(index);
        }

        public List<Estate> SearchEstate(FindEstateDto estate)
        {
            List<Estate> allEstates = _estateManager.GetAll();
            
            var result = from e in allEstates
                        where e.GetType().Equals(estate.Category.GetType())
                        || e.GetType().Equals(estate.GetType())
                        || e.Address.Street == estate.Street
                        || e.Address.ZipCode == estate.ZipCode
                        || e.Address.City == estate.City
                        || e.Address.Country == estate.Country
                        || e.LegalForm == estate.LegalForm
                        || e.EstateId == estate.EstateId
                         select e;

            return result.ToList();
        }

        private int SearchEstateById(string estateId)
        {
            return _estateManager.GetAll().FindIndex(e => e.EstateId == estateId);
        }

        private Estate CopyEstate(Estate estate)
        {
            Estate estateCopy;
            switch (estate.GetType().Name)
            {
                case "House":
                    estateCopy = new House()
                    {
                        EstateId = estate.EstateId,
                        LegalForm = estate.LegalForm,
                        Address = estate.Address
                    };
                    break;
                case "Apartment":
                    estateCopy = new Apartment()
                    {
                        EstateId = estate.EstateId,
                        LegalForm = estate.LegalForm,
                        Address = estate.Address
                    };
                    break;
                case "Shop":
                    estateCopy = new Shop()
                    {
                        EstateId = estate.EstateId,
                        LegalForm = estate.LegalForm,
                        Address = estate.Address
                    };
                    break;
                case "Townhouse":
                    estateCopy = new Townhouse()
                    {
                        EstateId = estate.EstateId,
                        LegalForm = estate.LegalForm,
                        Address = estate.Address
                    };
                    break;
                case "Villa":
                    estateCopy = new Villa()
                    {
                        EstateId = estate.EstateId,
                        LegalForm = estate.LegalForm,
                        Address = estate.Address
                    };
                    break;
                case "Warehouse":
                    estateCopy = new Warehouse()
                    {
                        EstateId = estate.EstateId,
                        LegalForm = estate.LegalForm,
                        Address = estate.Address
                    };
                    break;
                default:
                    estateCopy = null;
                    break;
            }
            return estateCopy;
        }

        private void Clear(Estate e)
        {
            e.EstateId = null;
            e.Address = null;
            e.LegalForm = default;
        }
    }
}
