using BLL.Controllers;
using BLL.DAL;
using BLL.Models;
using HomesForSales.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomesForSales
{
    public partial class Form1 : Form
    {
        private readonly IEstateController _estateController;
        private readonly IAddressController _addressController;
        private readonly IFileController _fileController;

        public Form1()
        {
            AddressManager am = new AddressManager();
            EstateManager em = new EstateManager();
            _fileController = new FileController(am, em);
            _estateController = new EstateController(em);
            _addressController = new AddressController(am);

            InitializeComponent();
            comboBoxCountries.DataSource = Enum.GetValues(typeof(Countries));
            comboBoxCountry.DataSource = Enum.GetValues(typeof(Countries));
            comboBoxCountryChange.DataSource = Enum.GetValues(typeof(Countries));
            comboBoxLegalForm.DataSource = Enum.GetValues(typeof(LegalForm));
            comboBoxChangeLegalForm.DataSource = Enum.GetValues(typeof(LegalForm));
            comboBoxAddLegalForm.DataSource = Enum.GetValues(typeof(LegalForm));
            comboBoxType.DataSource = _estateController.GetEstateTypes();
            comboBoxAddType.DataSource = _estateController.GetEstateTypes();
            comboBoxChangeType.DataSource = _estateController.GetEstateTypes();
            comboBoxCategory.DataSource = _estateController.GetEstateCategories();
            comboBoxEstateObject.DataSource = _estateController.GetAllEstates();
            comboBoxChangeEstateId.DataSource = _estateController.GetAllEstates().Select(e => e.EstateId).ToList();
            comboBoxAddAddressToEstate.DataSource = _addressController.GetAllAddresses();
            comboBoxChangeAddressForEstate.DataSource = _addressController.GetAllAddresses();
            comboBoxChangeAddress.DataSource = _addressController.GetAllAddresses();
        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddEstate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxEstateId.Text) || String.IsNullOrEmpty(comboBoxAddLegalForm.Text)
                || String.IsNullOrEmpty(comboBoxAddType.Text)
                || String.IsNullOrEmpty(comboBoxAddAddressToEstate.Text) || String.IsNullOrEmpty(comboBoxAddAddressToEstate.Text))
            {
                string errorMessage = "";
                if (String.IsNullOrEmpty(textBoxEstateId.Text))
                {
                    errorMessage = "Estate Id";
                }
                if (String.IsNullOrEmpty(comboBoxAddLegalForm.Text))
                {
                    errorMessage += " Legal form";
                }
                if (String.IsNullOrEmpty(comboBoxAddType.Text))
                {
                    errorMessage += " Type";
                }
                if (String.IsNullOrEmpty(comboBoxAddAddressToEstate.Text))
                {
                    errorMessage += " Address";
                }
                errorMessage += " must be specified.";
                System.Windows.Forms.MessageBox.Show(errorMessage);

            }
            else
            {
                Estate estate = (Estate)comboBoxType.SelectedItem;
                estate.EstateId = textBoxEstateId.Text;
                estate.LegalForm = (LegalForm)comboBoxAddLegalForm.SelectedItem;
                estate.Address = (Address)comboBoxAddAddressToEstate.SelectedItem;
                bool estateIsAdded = _estateController.AddEstate(estate);
                if (estateIsAdded)
                {
                    _fileController.UnsavedChanges = true;
                    System.Windows.Forms.MessageBox.Show("Estate is added.");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("An error occured when trying to add the estate.");
                }
            }

        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {
        }

        private void tabAdd_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEstateId_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAddNewAddress_Click(object sender, EventArgs e)
        {
            // If one of the fields are not filled in
            if (String.IsNullOrEmpty(textBoxStreet.Text) || String.IsNullOrEmpty(textBoxCity.Text) ||
                String.IsNullOrEmpty(textBoxZipCode.Text) || String.IsNullOrEmpty(textBoxZipCode.Text) ||
                String.IsNullOrEmpty(comboBoxCountries.Text))
            {
                string errorMessage = "";
                if (String.IsNullOrEmpty(textBoxStreet.Text))
                {
                    errorMessage = "Street";
                }
                if (String.IsNullOrEmpty(textBoxCity.Text))
                {
                    errorMessage += " City";
                }
                if (String.IsNullOrEmpty(textBoxZipCode.Text))
                {
                    errorMessage += " Zip Code";
                }
                if (String.IsNullOrEmpty(comboBoxCountries.Text))
                {
                    errorMessage += " Country";
                }
                errorMessage += " must be specified.";
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }
            else
            {
                bool addressIsAdded = _addressController.AddAddress(new Address(Guid.NewGuid().ToString(), textBoxStreet.Text, textBoxCity.Text,
                textBoxZipCode.Text, (Countries)comboBoxCountries.SelectedItem));
                if (addressIsAdded)
                {
                    _fileController.UnsavedChanges = true;
                    System.Windows.Forms.MessageBox.Show("Address is added.");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("An error occured when trying to add the address.");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Estate selectedEstate = (Estate)comboBoxEstateObject.SelectedItem;

            if (selectedEstate == null)
            {
                System.Windows.Forms.MessageBox.Show("Please choose an Estate Id for the Estate to be deleted!");
                return;
            }

            _estateController.DeleteEstate(selectedEstate);
            _fileController.UnsavedChanges = true;
            comboBoxEstateObject.SelectedItem = null;
        }


        private void buttonChangeEstate_Click(object sender, EventArgs e)
        {
            // If one of the fields are not filled in
            if (String.IsNullOrEmpty(comboBoxChangeEstateId.Text) || String.IsNullOrEmpty(comboBoxChangeLegalForm.Text) ||
                String.IsNullOrEmpty(comboBoxChangeAddressForEstate.Text))
            {
                string errorMessage = "";
                if (String.IsNullOrEmpty(comboBoxChangeEstateId.Text))
                {
                    errorMessage = "EstateId";
                }
                if (String.IsNullOrEmpty(comboBoxChangeLegalForm.Text))
                {
                    errorMessage += " Legal Form";
                }
                if (String.IsNullOrEmpty(comboBoxChangeType.Text))
                {
                    errorMessage += " Type";
                }
                if (String.IsNullOrEmpty(comboBoxChangeAddressForEstate.Text))
                {
                    errorMessage += " Address";
                }
                errorMessage += " must be specified.";
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }
            else
            {
                Estate estate = (Estate)comboBoxChangeType.SelectedItem;
                estate.EstateId = comboBoxChangeEstateId.Text;
                estate.LegalForm = (LegalForm)comboBoxChangeLegalForm.SelectedItem;
                estate.Address = (Address)comboBoxChangeAddressForEstate.SelectedItem;
                bool estateIsUpdated = _estateController.UpdateEstate(estate);
                if (estateIsUpdated)
                {
                    _fileController.UnsavedChanges = true;
                    System.Windows.Forms.MessageBox.Show("Estate is updated.");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("An error occured when trying to update the estate.");
                }
            }
        }

        private void buttonChangeAddress_Click(object sender, EventArgs e)
        {
            // If one of the fields are not filled in
            if (String.IsNullOrEmpty(textBoxStreetChange.Text) || String.IsNullOrEmpty(textBoxCityChange.Text) ||
                String.IsNullOrEmpty(textBoxZipCodeChange.Text) || String.IsNullOrEmpty(textBoxZipCodeChange.Text) ||
                String.IsNullOrEmpty(comboBoxCountryChange.Text))
            {
                string errorMessage = "";
                if (String.IsNullOrEmpty(textBoxStreetChange.Text))
                {
                    errorMessage = "Street";
                }
                if (String.IsNullOrEmpty(textBoxCityChange.Text))
                {
                    errorMessage += " City";
                }
                if (String.IsNullOrEmpty(textBoxZipCodeChange.Text))
                {
                    errorMessage += " Zip Code";
                }
                if (String.IsNullOrEmpty(comboBoxCountryChange.Text))
                {
                    errorMessage += " Country";
                }
                errorMessage += " must be specified.";
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }
            else
            {
                Address addressToChange = (Address)comboBoxChangeAddress.SelectedItem;
                addressToChange.Street = textBoxStreetChange.Text;
                addressToChange.City = textBoxCityChange.Text;
                addressToChange.ZipCode = textBoxZipCodeChange.Text;
                addressToChange.Country = (Countries)comboBoxCountryChange.SelectedItem;

                bool addressIsUpdated = _addressController.UpdateAddress(addressToChange);
                if (addressIsUpdated)
                {
                    _fileController.UnsavedChanges = true;
                    System.Windows.Forms.MessageBox.Show("Address is updated.");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("An error occured when trying to update the address.");
                }
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            FindEstateDto searchObj = new FindEstateDto();
            searchObj.EstateId = textBoxFindEstateId.Text;
            searchObj.LegalForm = (LegalForm)comboBoxLegalForm.SelectedItem;
            searchObj.Type = (Estate)comboBoxType.SelectedItem;
            searchObj.Category = (Estate)comboBoxCategory.SelectedItem;
            searchObj.Street = textBoxFindStreet.Text;
            searchObj.ZipCode = textBoxFindZipcode.Text;
            searchObj.City = textBoxFindCity.Text;
            searchObj.Country = (Countries)comboBoxCountry.SelectedItem;
            var result = _estateController.SearchEstate(searchObj);
            dataGridViewEstates.DataSource = result;
        }

        private void btnUpdateAddressAddEstate_Click(object sender, EventArgs e)
        {
            comboBoxAddAddressToEstate.DataSource = _addressController.GetAllAddresses();
        }

        private void btnUpdateEstatesDelete_Click(object sender, EventArgs e)
        {
            comboBoxEstateObject.SelectedItem = null;
            comboBoxEstateObject.DataSource = _estateController.GetAllEstates();
        }

        private void btnUpdateAddressesChangeEstate_Click(object sender, EventArgs e)
        {
            comboBoxChangeAddressForEstate.DataSource = _addressController.GetAllAddresses();
        }

        private void btnUpdateAddressesChangeAddress_Click(object sender, EventArgs e)
        {
            comboBoxChangeAddress.DataSource = _addressController.GetAllAddresses();
        }

        private void mnuFileNew_Click(object sender, EventArgs e)
        {
            _fileController.New(() =>
            {
                DialogResult dialogResult = MessageBox.Show("Vill du fortsätta? Osparade ändringar kommer förloras", "Fortsätt utan att spara", MessageBoxButtons.YesNo);
                return dialogResult == DialogResult.Yes;
            });
            UpdateGui();
        }

        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                bool success = _fileController.Open(openFileDialog.FileName);
                if (success)
                    UpdateGui();
            }
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            bool success = _fileController.Save(() =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                var result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    return saveFileDialog.FileName;
                }
                return null;
            });
            if (success)
                MessageBox.Show("Successful save");
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                bool success = _fileController.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Successful save");
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdateGui()
        {
            comboBoxEstateObject.SelectedItem = null;
            comboBoxEstateObject.DataSource = _estateController.GetAllEstates();
            comboBoxChangeEstateId.SelectedItem = null;
            comboBoxChangeEstateId.DataSource = _estateController.GetAllEstates().Select(e => e.EstateId).ToList();
            comboBoxAddAddressToEstate.SelectedItem = null;
            comboBoxAddAddressToEstate.DataSource = _addressController.GetAllAddresses();
            comboBoxChangeAddressForEstate.SelectedItem = null;
            comboBoxChangeAddressForEstate.DataSource = _addressController.GetAllAddresses();
            comboBoxChangeAddress.SelectedItem = null;
            comboBoxChangeAddress.DataSource = _addressController.GetAllAddresses();
        }
    }
}

