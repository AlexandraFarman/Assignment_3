using BLL.Controllers;
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
        private IEstateController estateController;
        private IAddressController addressController;


        public Form1()
        {
            estateController = new EstateController();
            addressController = new AddressController();
            InitializeComponent();
            comboBoxCountries.DataSource = Enum.GetValues(typeof(Countries));
            comboBoxCountry.DataSource = Enum.GetValues(typeof(Countries));
            comboBoxCountryChange.DataSource = Enum.GetValues(typeof(Countries));
            comboBoxLegalForm.DataSource = Enum.GetValues(typeof(LegalForm));
            comboBoxChangeLegalForm.DataSource = Enum.GetValues(typeof(LegalForm));
            comboBoxAddLegalForm.DataSource = Enum.GetValues(typeof(LegalForm));
            comboBoxType.DataSource = estateController.GetEstateTypes();
            comboBoxAddType.DataSource = estateController.GetEstateTypes();
            comboBoxChangeType.DataSource = estateController.GetEstateTypes();
            comboBoxAddCategory.DataSource = estateController.GetEstateCategories();
            comboBoxCategory.DataSource = estateController.GetEstateCategories();
            comboBoxEstateObject.DataSource = estateController.GetAllEstates();
            comboBoxChangeEstateId.DataSource = estateController.GetAllEstates().Select(e => e.EstateId).ToList();
            comboBoxAddAddressToEstate.DataSource = addressController.GetAllAddresses();
            comboBoxChangeAddressForEstate.DataSource = addressController.GetAllAddresses();
            comboBoxChangeAddress.DataSource = addressController.GetAllAddresses();
        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddEstate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxEstateId.Text) || String.IsNullOrEmpty(comboBoxAddLegalForm.Text)
                || String.IsNullOrEmpty(comboBoxAddCategory.Text) || String.IsNullOrEmpty(comboBoxAddType.Text)
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
                if (String.IsNullOrEmpty(comboBoxAddCategory.Text))
                {
                    errorMessage += " Category";
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
                bool estateIsAdded = estateController.AddEstate(estate);
                if (estateIsAdded)
                {
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
                bool addressIsAdded = addressController.AddAddress(new Address(textBoxStreet.Text, textBoxCity.Text,
                textBoxZipCode.Text, (Countries)comboBoxCountries.SelectedItem));
                if (addressIsAdded)
                {
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

            estateController.DeleteEstate(selectedEstate);
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
                bool estateIsUpdated = estateController.UpdateEstate(estate);
                if (estateIsUpdated)
                {
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

                bool addressIsUpdated = addressController.UpdateAddress(addressToChange);
                if (addressIsUpdated)
                {
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
            var result = estateController.SearchEstate(searchObj);
            dataGridViewEstates.DataSource = result;
        }
    }
}

