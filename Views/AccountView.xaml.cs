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
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : Page
    {
        // Used to pass user data as a parameter for required views
        string _user;

        // Load methods when page is opened
        public AccountView()
        {
            InitializeComponent();
            DisplayAccountBalanceAmount();
        }

        // Overload constructor, Load methods when page is opened
        public AccountView(string user)
        {
            InitializeComponent();
            DisplayAccountBalanceAmount();
            _user = user;
            DisplayUsername();
        }

        // Open HomepageView
        private void OpenHomeView_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        // Method used to display users username
        private void DisplayUsername()
        {
            DisplayUsernameLabel.Content = _user;
        }

        //Algorithmn to calculate users account balance
        private void DisplayAccountBalanceAmount()
        {
            decimal incomeBalance = 0;
            decimal expenseBalance = 0;

            //Loop through financedetails list
            foreach (var item in FinanceDetails.Finances)
            {

                // Adding amount for Income data 
                if (item.FinanceType.Equals("Income"))
                {
                    incomeBalance += item.Amount;

                }

                // Adding amount for Expense data 
                if (item.FinanceType.Equals("Expense"))
                {
                    expenseBalance += item.Amount;
                }
            }

            // Calculate the users account balance
            decimal accountBalance = incomeBalance - expenseBalance;
            // Formatting decimal display: Round up the accoutn balance to two decimal positions after the decimal point
            accountBalance = (Decimal)System.Math.Round(accountBalance, 2);
            // Display the calculated account balance  in AccountBalanceAmount label 
            AccountBalanceAmount.Content = $"Account Balance:  {accountBalance}";
        }

    }
}
