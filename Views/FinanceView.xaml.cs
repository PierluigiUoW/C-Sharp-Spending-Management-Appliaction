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
using w1640643CW2.Views;

namespace w1640643CW2
{
    /// <summary>
    /// Interaction logic for FinanceView.xaml
    /// </summary>
    public partial class FinanceView : Page
    {
        // Used to pass finance data as a parameter for required views

        Finance iFinance = new Finance();

        // Load methods when page is opened

        public FinanceView()
        {
            InitializeComponent();
            DisplayFinanceDetails();
        }

        // Open HomepageView

        private void OpenHomeView(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new HomepageView());
        }

        // Open CreateFinanceView

        private void CreateNewFinanceRecordButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateFinanceView());
        }

        // Adds list FinanceDetails to the listbox and refreshed listbox to ensure listbox is updated

        private void DisplayFinanceDetails()
        {
            FinanceDetailsListBox.ItemsSource = FinanceDetails.Finances;

            FinanceDetailsListBox.Items.Refresh();
        }

        // Delete finance record

        private void DeleteFinanceButton_Click(object sender, RoutedEventArgs e)
        {
            // Loop through FinanceDetails list

            foreach (var finance in FinanceDetails.Finances)
            {

                // Validates which item the user has selected within the listbox 

                if (FinanceDetailsListBox.SelectedItem == finance)
                {

                    // Removes selected item data from FinanceDetails list

                    FinanceDetails.Finances.Remove(finance);

                    // Update data and save to file

                    Seralize(FinanceDetails.Finances);

                    // Call method to update the listbox

                    DisplayFinanceDetails();

                    return;
                }
            }
        }

        //Method to save the data to file to be saved future use in application

        private void Seralize(List<Finance> finances)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(finances);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\finances.txt";

            WriteObjectToFile(path, jsonContent);
        }

        // Method to write data to file

        private void WriteObjectToFile(string path, string jsonContent)
        {
            File.WriteAllText(path, jsonContent);
        }

        // Open EditFinanceView with finance data passed as parameter

        private void EditFinanceRecord_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditFinanceView(iFinance));
        }

        private void FinanceDetailsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;

            var item = listBox.SelectedItem as Finance;

            iFinance = (Finance)item;

            DisplayFinanceDetails();
        }

        // Open ReceiptView with finance data passed as parameter

        private void ViewReceiptsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReceiptView(iFinance));
        }
    }
}
