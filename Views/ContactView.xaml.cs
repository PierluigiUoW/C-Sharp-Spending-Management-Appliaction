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
    /// Interaction logic for ContactView.xaml
    /// </summary>
    public partial class ContactView : Page
    {
        // Used to pass contact data as a parameter for required views
        private Contact iContact = new Contact();

        // Load methods when page is opened
        public ContactView()
        {
            InitializeComponent();
            DisplayContactDetails();
        }

        // Open HomepageView
        private void ReturnToHomeView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomepageView());
        }

        // Open CreateContactView
        private void CreateContactButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateContactView());
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;

            var item = listBox.SelectedItem as Contact;

            iContact = (Contact)item;

            DisplayContactDetails();
        }

        // Adds list ContactDetails to the listbox and refreshed listbox to ensure listbox is updated
        private void DisplayContactDetails()
        {
            ContactDetailsListBox.ItemsSource = ContactDetails.contacts;

            ContactDetailsListBox.Items.Refresh();
        }

        // Delete contact record
        private void DeleteSelectedContactRecord_Click(object sender, RoutedEventArgs e)
        {
            // Loop through ContactDetails list
            foreach (var contact in ContactDetails.contacts)
            {

                // Validates which item the user has selected within the listbox 
                if (ContactDetailsListBox.SelectedItem == contact)
                {
                    // MessageBox.Show("HERE");
                    // Removes selected item data from ContactDetails list
                    ContactDetails.contacts.Remove(contact);
                    // Update data and save to file
                    Seralize(ContactDetails.contacts);

                    // Call method to update the listbox
                    DisplayContactDetails();

                    return;
                }
            }

        }

        // Open EditContactView with contact data passed as parameter
        private void EditSelectedContactRecord_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditContactView(iContact));
        }

        //Method to save the data to file to be saved future use in application
        private static void Seralize(List<Contact> contact)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(contact);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\contacts.txt";

            WriteObjectToFile(path, jsonContent);
        }

        // Method to write data to file
        private static void WriteObjectToFile(string path, string jsonContent)
        {
            File.WriteAllText(path, jsonContent);
        }


    }
}
