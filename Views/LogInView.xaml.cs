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
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : Page
    {
        //Load all file data on load of LogInView
        public LogInView()
        {
            InitializeComponent();

            // Call methods used to handle FileNotFound exception from FileExceptionHandler class
            FileExceptionHandler fileHandler = new FileExceptionHandler();

            fileHandler.UserFileExceptionHandler();
            fileHandler.ContactFileExceptionHandler();
            fileHandler.FinanceFileExceptionHandler();
            fileHandler.PredictionFileExceptionHandler();
            fileHandler.ReportFileExceptionHandler();

            Deseralize();
            DeseralizeContacts();
            DeseralizeFinances();
            DeseralizePrediction();

            //ATTEMP AT THREADING:
            // Call methods to load JSON data from a different thread, from ThreadWorker class
            //ThreadedWorker tw = new ThreadedWorker();

            //tw.Deseralize();
            //tw.DeseralizeContacts();
            //tw.DeseralizeFinances();
            //tw.DeseralizePrediction();
            //tw.DeseralizeReport();
            //tw.doWork();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {

            if (EmailAddressTextBox.Text == string.Empty || PasswordPwdBox.Password == string.Empty)
            {
                MessageBox.Show("Please enter your credentials");
            }
            else

            {
                //loop throuh list of Registered Users
                foreach (var regUserData in RegisteredUsers.Users)
                {
                    /*if details of a registered user match the users entered credentials, allow them to access the application and
                     * navigate the user to the HomepageView
                    */

                    if (EmailAddressTextBox.Text.Equals(regUserData.EmailAddress)
                        && PasswordPwdBox.Password.Equals(regUserData.Password))
                    {
                        //NavigationService.Navigate(new HomepageView(iUser));
                        NavigationService.Navigate(new HomepageView(regUserData.Username));
                        return;
                    }
                }

                //if details of a registered user does not match the users entered credentials, display a error message box

                MessageBox.Show("Could not find account with provided credentials", "Log In Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //Methods to load the data from files to be used for the application

        private static void Deseralize()
        {
            JSON json = new JSON();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\user.txt";

            string jsonContent = ReadFromFile(path);

            RegisteredUsers.Users = json.DeserializeList(jsonContent);

        }

        private static void DeseralizeContacts()
        {
            JSON json = new JSON();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\contacts.txt";

            string jsonContent = ReadFromFile(path);

            ContactDetails.contacts = json.DeserializeListContact(jsonContent);
        }

        private static void DeseralizeFinances()
        {
            JSON json = new JSON();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\finances.txt";

            string jsonContent = ReadFromFile(path);

            FinanceDetails.Finances = json.DeserializeListFinance(jsonContent);
        }

        private static void DeseralizePrediction()
        {
            JSON json = new JSON();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\prediction.txt";

            string jsonContent = ReadFromFile(path);

            PredictionDetails.Prediction = json.DeserializeListPrediction(jsonContent);
        }

        // Method to read data from file

        private static string ReadFromFile(string path)
        {
                return File.ReadAllText(path);
        }

        //Open ForgottenPasswordView

        private void ForgottenPasswordLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ForgottenPasswordView());
        }

        //Open ForgottenEmailAddressView

        private void ForgottenEmailLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ForgottenEmailAddressView());
        }

        //Open RegisterView

        private void RegisterAccountLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegisterView());
        }
    }
}

