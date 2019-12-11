using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public interface IFileController
    {
        bool UnsavedChanges { get; set; }
        void New(Func<bool> askIfSure);
        bool Open(string filename);
        bool Save(Func<string> chooseFileName);
        bool SaveAs(string filename);

    }
}
