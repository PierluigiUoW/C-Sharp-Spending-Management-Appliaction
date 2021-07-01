using System;
using System.Collections.Generic;
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
    /// Interaction logic for HomepageView.xaml
    /// </summary>
    public partial class HomepageView : Page
    {
        // Used to pass user data as a parameter for required views

        string _user;

        // Load methods when page is opened

        public HomepageView()
        {
            InitializeComponent();
        }
        public HomepageView(string iUser)
        {
            InitializeComponent();
            _user = iUser;
        }

        // Open AccountView with user data passed as parameter

        private void OpenAccountButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AccountView(_user));
        }

        // Open ContactView

        private void OpenContactButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ContactView());
        }

        // Open FinanceView

        private void OpenFinancetButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FinanceView());
        }

        // Open PredictionView

        private void OpenPredictionButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PredictionView());
        }

        // Open ReportView

        private void OpenReportButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReportView());
        }
    }
}
