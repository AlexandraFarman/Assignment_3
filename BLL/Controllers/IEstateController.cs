using BLL.Models;
using HomesForSales.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public interface IEstateController
    {
        List<Estate> GetEstateTypes();
        List<Estate> GetEstateCategories();
        List<Estate> GetAllEstates();
        bool AddEstate(Estate estate);
        bool UpdateEstate(Estate estate);
        bool DeleteEstate(Estate estate);
        List<Estate> SearchEstate(FindEstateDto estate);
    }
}
