using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using w1640643CW2.Models;

namespace w1640643CW2.Views
{
    /// <summary>
    /// Interaction logic for EditContactView.xaml
    /// </summary>
    public partial class EditContactView : Page
    {
        // Used to update that has been passes as paramater from FinanceView

        Contact _iContact = new Contact();

        // Load methods when page is opened

        public EditContactView()
        {
            InitializeComponent();
        }

        // Overall of constructor, Load methods when page is opened

        public EditContactView(Contact iContact)
        {
            InitializeComponent();
            _iContact = iContact;
            DisplayContactDetails();
        }

        // Method to display initial details of the selected finance

        private void DisplayContactDetails()
        {

            // Display selected finance data in the corresponding labels

            ContactFirstNameLabel.Content = _iContact.FirstName;
            ContactLastNameLabel.Content = _iContact.LastName;
            ContactNumberLabel.Content = _iContact.Number;
            ContactEmailAddressLabel.Content = _iContact.EmailAddress;

            UpdateContactFirstNameTextBox.Text = _iContact.FirstName;
            UpdateCContactLastNameTextBox.Text = _iContact.LastName;
            UpdateCContactNumberTextBox.Text = _iContact.Number;
            UpdateCContactEmailAddressTextBox.Text = _iContact.EmailAddress;
        }

        //Method to save the data to file to be saved future use in application

        private static void Seralize(List<Contact> contacts)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(contacts);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\contacts.txt";

            WriteObjectToFile(path, jsonContent);
        }

        // Method to write data to file

        private static void WriteObjectToFile(string path, string jsonContent)
        {
            File.WriteAllText(path, jsonContent);
        }

        // Open ContactView

        private void GoBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ContactView());
        }

        private void UpdateContactRecordButton_Click(object sender, RoutedEventArgs e)
        {

            // Loop through ContactDetails list
            try
            {

                foreach (var contact in ContactDetails.contacts)
                {

                    //Validation

                    if (contact.FirstName.Equals(ContactFirstNameLabel.Content) && UpdateContactFirstNameTextBox.Text != string.Empty
                        && contact.LastName.Equals(ContactLastNameLabel.Content) && UpdateCContactLastNameTextBox.Text != string.Empty
                        && contact.Number.Equals(ContactNumberLabel.Content) && UpdateCContactNumberTextBox.Text != string.Empty 
                        && contact.EmailAddress.Equals(ContactEmailAddressLabel.Content) && UpdateCContactEmailAddressTextBox.Text != string.Empty)
                    {

                        MessageBox.Show("Contact record successful!y updated!");

                        // Updating data of object in ContactDetails list

                        contact.FirstName = UpdateContactFirstNameTextBox.Text;
                        contact.LastName = UpdateCContactLastNameTextBox.Text;
                        contact.Number = UpdateCContactNumberTextBox.Text;
                        contact.EmailAddress = UpdateCContactEmailAddressTextBox.Text;

                        // Save new data to file

                        Seralize(ContactDetails.contacts);

                        // Disables being able to use textboxes on the page after submittion and save

                        UpdateContactFirstNameTextBox.IsEnabled = false;
                        UpdateCContactLastNameTextBox.IsEnabled = false;
                        UpdateCContactNumberTextBox.IsEnabled = false;
                        UpdateCContactEmailAddressTextBox.IsEnabled = false;
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Exception Handled: " + ex.Message);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Exception Handled: " + ex.Message);
            }
        }

    }
}