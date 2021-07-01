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
    /// Interaction logic for PredictionView.xaml
    /// </summary>
    public partial class PredictionView : Page

    {

        // Load methods when page is opened

        public PredictionView()
        {
            InitializeComponent();
            DisplayPredictionDetails();
        }

        // Open HomePageView

        private void OpenHomeView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        // Method for Prediction algorithm

        private void CreateNewPrediction_Click(object sender, RoutedEventArgs e)
        {

            if (PredictionNameTextBox.Text == string.Empty || FuturePreidictionDateDatePicker.SelectedDate == null
                || StartDateDatePicker.SelectedDate == null || EndDateDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Please ensure a name for the prediction and the datse have been selected!");
            }

            else
            {
                // Validation of date to ensure prediction date is set in the future

                try
                {
                    if (FuturePreidictionDateDatePicker.SelectedDate > DateTime.Now)
                    {

                        MessageBox.Show("Successfully validated credentials. Creating prediction ... ");

                        decimal totalIncome = 0;
                        int incomeCount = 0;

                        decimal totalExpense = 0;
                        int expenseCount = 0;

                        decimal avgIncome = 0;
                        decimal avgExpense = 0;

                        //Loop through the FinanceDetails list

                        foreach (var item in FinanceDetails.Finances)
                        {

                            // Search for data within FinanceDetails list that match the date validation

                            if (item.CreationDateTime >= StartDateDatePicker.SelectedDate
                                && item.CreationDateTime <= EndDateDatePicker.SelectedDate)
                            {

                                // Adding amount for Income data 

                                if (item.FinanceType.Equals("Income"))
                                {
                                    totalIncome += item.Amount;

                                    // Incremending incomeCount by 1
                                    incomeCount++;
                                }

                                // Adding amiunt for Expense data

                                if (item.FinanceType.Equals("Expense"))
                                {
                                    // Adding amount for Income data 

                                    totalExpense += item.Amount;

                                    // Incremending expenseCount by 1

                                    expenseCount++;
                                }

                            }


                            // Validation to ensure we can calculate the average

                            if (incomeCount > 0)
                            {
                                // Calculate the average of Income

                                avgIncome = totalIncome / incomeCount;
                            }

                            if (expenseCount > 0)
                            {
                                // Calculate the average of Expense

                                avgExpense = totalExpense / expenseCount;
                            }

                            // Calculate the overall average for users prediction

                            decimal balance = avgIncome - avgExpense;


                            // Formatting decimal display: Round up the average to two decimal positions after the decimal point

                            balance = (Decimal)System.Math.Round(balance, 2);

                            // Display the calculated overall average in PredictionCalulcationLabel label 

                            PredictionCalulcationLabel.Content = $"Prediction: {balance}";

                            Prediction predict = new Prediction();

                            //predict.PredictedAccountBalance = calculatedPrediction;
                            predict.Name = PredictionNameTextBox.Text;
                            predict.PredictedAccountBalance = balance;

                            predict.PreidctionDate = (DateTime)FuturePreidictionDateDatePicker.SelectedDate;

                            PredictionDetails.Prediction.Add(predict);

                            Seralize(PredictionDetails.Prediction);

                            DisplayPredictionDetails();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Invalid date selected");
                    }
                }

                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Exception handled: " + ex.Message);
                }


            }

        }

        //Method to save the data to file to be saved future use in application

        private static void Seralize(List<Prediction> prediction)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(prediction);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\prediction.txt";

            WriteObjectToFile(path, jsonContent);
        }

        // Method to write data to file

        private static void WriteObjectToFile(string path, string jsonContent)
        {
            File.WriteAllText(path, jsonContent);
        }

        // Adds list PredictionDetails to the listbox and refreshed listbox to ensure listbox is updated

        private void DisplayPredictionDetails()
        {

            PredictionDetailsListBox.ItemsSource = PredictionDetails.Prediction;

            PredictionDetailsListBox.Items.Refresh();
        }
    }
}
