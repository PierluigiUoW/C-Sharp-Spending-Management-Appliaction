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
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : Page
    {

        // Load methods when page is opened

        public ReportView()
        {
            InitializeComponent();
            DeseralizeReport();
            DisplayReportDetails();
        }

        // Open HomePageView

        private void OpenHomeView(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        // Method to create new repots in listbox

        private void CreateNewReportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Loop through the FinanceDetails list
                if (ReportNameTextBox.Text == string.Empty || StartDateDatePicker.SelectedDate == null
                    || EndDateDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Please ensure a name for the report and dates have been selected!");
                }

                else
                {
                    foreach (var item in FinanceDetails.Finances)
                    {
                        //Cannot be OR expression as this will retrieve everthing greater...
                        // than startdatedatepicker, which we do not want, want finances 
                        //greter than start and less than end dates to be shown 

                        // Search for data within FinanceDetails list that match the date validation

                        if (item.CreationDateTime >= StartDateDatePicker.SelectedDate
                            && item.CreationDateTime <= EndDateDatePicker.SelectedDate)
                        {
                            decimal incomeAmount = 0;
                            decimal expenseAmount = 0;

                            // Adding amount for Income data 

                            if (item.FinanceType.Equals("Income"))
                            {
                                incomeAmount += item.Amount;
                            }

                            // Adding amiunt for Expense data

                            if (item.FinanceType.Equals("Expense"))
                            {
                                expenseAmount += item.Amount;
                            }

                            // Find out the account balance

                            decimal accountAmount = incomeAmount - expenseAmount;

                            Report report = new Report();

                            // Assiging data

                            report.Finance = accountAmount;
                            report.Name = ReportNameTextBox.Text;
                            report.ReportCreationDate = DateTime.Now;

                            if (Reports.ReportDetails == null)
                                Reports.ReportDetails = new List<Report>();


                            Reports.ReportDetails.Add(report);

                            // Saving data to file

                            Seralize(Reports.ReportDetails);

                            // Calling method to add and update listbox in view

                            DisplayReportDetails();
                        }

                    }
                }
            }

            catch (NullReferenceException ex)
            {
                MessageBox.Show("Exception Handled: " + ex.Message);
            }

        }

        //Method to save the data to file to be saved future use in application

        private static void Seralize(List<Report> reports)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(reports);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\report.txt";

            WriteObjectToFile(path, jsonContent);
        }

        // Method to write data to file

        private static void WriteObjectToFile(string path, string jsonContent)
        {
            File.WriteAllText(path, jsonContent);
        }

        //Method to load the data from file to be used for the application

        private static void DeseralizeReport()
        {
            JSON json = new JSON();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\report.txt";

            string jsonContent = ReadFromFile(path);

            Reports.ReportDetails = json.DeserializeListReport(jsonContent);
        }

        // Method to read data from file

        private static string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        // Adds list Reports to the listbox and refreshed listbox to ensure listbox is updated

        private void DisplayReportDetails()
        {
            ReportDetailsListBox.ItemsSource = Reports.ReportDetails;

            ReportDetailsListBox.Items.Refresh();
        }


    }
}





