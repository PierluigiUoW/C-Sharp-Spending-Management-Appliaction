using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using w1640643CW2.Models;

namespace w1640643CW2.Views
{
    /// <summary>
    /// Interaction logic for EditFinanceView.xaml
    /// </summary>
    public partial class EditFinanceView : Page
    {
        // Used to update that has been passes as paramater from FinanceView

        Finance _finance = new Finance();

        // Load methods when page is opened

        public EditFinanceView()
        {
            InitializeComponent();
        }

        // Overall of constructor, Load methods when page is opened

        public EditFinanceView(Finance iFinance)
        {
            InitializeComponent();
            _finance = iFinance;

            DisplayFinanceDetails();
            DisplayComboBoxContacts();
            DisplayComboBoxFinanceTypes();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            // Loop through FinanceDetails list
            try
            {
                foreach (var finance in FinanceDetails.Finances)
                {
                    //Validation

                    if (finance.FinanceName.Equals(FinanceNameLabelContent.Content) && FinanceUpdateNameTextBox.Text != string.Empty
                        && finance.FinanceDescription.Equals(FinanceDescriptionLabelContent.Content) && FinanceUpdateDescriptionTextBox.Text != string.Empty
                        && FinanceUpdateAmountTextBox.Text != string.Empty
                        && FinanceUpdateTypeComboBox.SelectedIndex > -1
                        && FinanceUpdateContactCombobox.SelectedIndex > -1)
                    {

                        // Allows for FinanceUpdateAmountTextBox text to be used as a decimal variable

                        decimal.TryParse(FinanceUpdateAmountTextBox.Text, out decimal amount);

                        // Updating data of object in FinanceDetails list

                        finance.FinanceName = FinanceUpdateNameTextBox.Text;
                        finance.FinanceDescription = FinanceUpdateDescriptionTextBox.Text;
                        finance.FinanceType = FinanceUpdateTypeComboBox.SelectedItem.ToString();
                        finance.Amount = amount;
                        finance.FinanceContact = FinanceUpdateContactCombobox.SelectedItem.ToString();

                        // Save new data to file

                        Seralize(FinanceDetails.Finances);

                        // Disables being able to use textboxes on the page after submittion and save

                        FinanceUpdateNameTextBox.IsEnabled = false;
                        FinanceUpdateDescriptionTextBox.IsEnabled = false;
                        FinanceUpdateTypeComboBox.IsEnabled = false;
                        FinanceUpdateAmountTextBox.IsEnabled = false;
                        FinanceUpdateContactCombobox.IsEnabled = false;

                        MessageBox.Show("Finance record successful!y updated!");
                        break;
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

        // Method to display initial details of the selected finance

        private void DisplayFinanceDetails()
        {

            // Display selected finance data in the corresponding labels

            FinanceNameLabelContent.Content = _finance.FinanceName;
            FinanceDescriptionLabelContent.Content = _finance.FinanceDescription;
            FinanceTypeLabelContent.Content = _finance.FinanceType;
            FinanceAmountLabelContent.Content = _finance.Amount.ToString();
            FinanceContactLabelContent.Content = _finance.FinanceContact;

            FinanceUpdateNameTextBox.Text = _finance.FinanceName;
            FinanceUpdateDescriptionTextBox.Text = _finance.FinanceDescription;
            FinanceUpdateTypeComboBox.Text = _finance.FinanceType;
            FinanceUpdateAmountTextBox.Text = _finance.Amount.ToString();
            FinanceUpdateContactCombobox.Text = _finance.FinanceContact; 
        }

        // Method used to display initial FinanceUpdateContact combobox 

        public void DisplayComboBoxContacts()
        {
            // Loop through ContactDetails list

            foreach (var item in ContactDetails.contacts)
            {
                // Add the data of firstname and lastname of ContactDetails to the FinanceUpdateContact Combobox
                FinanceUpdateContactCombobox.Items.Add(item.FirstName + " " + item.LastName);
            }
        }

        // Method used to display initial FinanceUpdateType combobox 

        public void DisplayComboBoxFinanceTypes()
        {
            // Add strings of Income and Expense to FinanceUpdateType combobox

            FinanceUpdateTypeComboBox.Items.Add("Income");
            FinanceUpdateTypeComboBox.Items.Add("Expense");
        }

        //Method to save the data to file to be saved future use in application

        private static void Seralize(List<Finance> finance)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(finance);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\finances.txt";

            WriteObjectToFile(path, jsonContent);
        }

        // Method to write data to file

        private static void WriteObjectToFile(string path, string jsonContent)
        {
            File.WriteAllText(path, jsonContent);
        }

        // Opens FinanceView

        private void GoBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new FinanceView());
        }
    }
}
