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
    /// Interaction logic for ReceiptView.xaml
    /// </summary>
    public partial class ReceiptView : Page
    {
        // Create object of fiance to retrieve required data
        Finance _finance = new Finance();

        //Methods to load when page is opened
        public ReceiptView()
        {
            InitializeComponent();
        }

        //Overload constructor with additional methods to load when page is opened
        public ReceiptView(Finance iFinance)
        {
            InitializeComponent();
            _finance = iFinance;
            DisplayReceiptContent();
        }

        
        public void DisplayReceiptContent()
        {
            //Set labels to the data of finance object retrieved
            FinanceNameLabelContent.Content = _finance.FinanceName;
            FinanceDescriptionLabelContent.Content = _finance.FinanceName;
            FinanceTypeLabelContent.Content = _finance.FinanceType;
            FinanceAmountLabelContent.Content = _finance.Amount.ToString();
            FinanceContactLabelContent.Content = _finance.FinanceContact;
        }

        //Method to go back to Fiannce View
        private void GoBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
