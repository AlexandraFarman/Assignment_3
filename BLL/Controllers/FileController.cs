using BLL.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Controllers
{
    public class FileController : IFileController
    {
        public bool UnsavedChanges { get; set; }

        private readonly AddressManager _addressManager;
        private readonly EstateManager _estateManager;
        private string chosenFileName;

        public FileController(AddressManager am, EstateManager em)
        {
            _addressManager = am;
            _estateManager = em;
        }

        public void New(Func<bool> askIfSure)
        {
            if (UnsavedChanges)
            {
                if (!askIfSure())
                    return;
            }

            _addressManager.DeleteAll();
            _estateManager.DeleteAll();
            UnsavedChanges = false;
        }

        public bool Open(string filename)
        {
            bool result = false;
            if (filename.EndsWith(".estates"))
            {
                string filenameWithoutSuffix = filename.Replace(".estates", "");
                result = _estateManager.BinaryDeserialize(filenameWithoutSuffix + ".estates");
                if (!result)
                    return false;

                if(File.Exists(filenameWithoutSuffix + ".addresses"))
                {
                    result = _addressManager.BinaryDeserialize(filenameWithoutSuffix + ".addresses");
                }
            }
            else if (filename.EndsWith(".addresses"))
            {
                string filenameWithoutSuffix = filename.Replace(".addresses", "");
                result = _addressManager.BinaryDeserialize(filenameWithoutSuffix + ".addresses");
                if (!result)
                    return false;

                if (File.Exists(filenameWithoutSuffix + ".estates"))
                {
                    result = _estateManager.BinaryDeserialize(filenameWithoutSuffix + ".estates");
                }
            }
            UnsavedChanges = false;
            return result;
        }

        public bool Save(Func<string> chooseFileName)
        {
            if (string.IsNullOrEmpty(chosenFileName))
            {
                chosenFileName = chooseFileName();
                if (chooseFileName == null)
                    return false;
            }

            bool estateSave = _estateManager.BinarySerialize(chosenFileName + ".estates");
            bool addressSave = _addressManager.BinarySerialize(chosenFileName + ".addresses");
            if(estateSave && addressSave)
            {
                UnsavedChanges = false;
                return true;
            }
            return false;
        }

        public bool SaveAs(string filename)
        {
            chosenFileName = filename;
            bool estateSave = _estateManager.BinarySerialize(filename + ".estates");
            bool addressSave = _addressManager.BinarySerialize(filename + ".addresses");
            if (estateSave && addressSave)
            {
                UnsavedChanges = false;
                return true;
            }
            return false;
        }
    }
}
