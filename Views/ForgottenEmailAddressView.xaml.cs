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
    /// Interaction logic for ForgottenEmailAddressView.xaml
    /// </summary>
    public partial class ForgottenEmailAddressView : Page
    {
        // Load methods on page open

        public ForgottenEmailAddressView()
        {
            InitializeComponent();
        }

        // Method to update user email address

        private void UpdateEmailButton_Click(object sender, RoutedEventArgs e)
        {
            if (ForgottenEmailUsernameTextBox.Text == string.Empty || ForgottenEmailAddressSecurityQuestionTextBox.Text == string.Empty
                || UpdateEmailAddressTextBox.Text == string.Empty)
            {
                MessageBox.Show("Please enter your credentials and a new email address to use");
            }

            else
            {
                // Loop through the RegisteredUsers list

                foreach (var regUserData in RegisteredUsers.Users)
                {
                    // Validating users entered credentials to data within RegisteredUsers list

                    if (regUserData.Username.Equals(ForgottenEmailUsernameTextBox.Text)
                        && regUserData.SecurityQuestion.Equals(ForgottenEmailAddressSecurityQuestionTextBox.Text))
                    {
                        // Update email address data with new email address entered

                        regUserData.EmailAddress = UpdateEmailAddressTextBox.Text;

                        // Save the new data to file

                        Seralize(RegisteredUsers.Users);
                        MessageBox.Show("Email Address updated to: " + regUserData.EmailAddress);
                        return;
                    }
                }
                MessageBox.Show("Could not find account with provided credentials", "Update Email Address Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Opens HomepageView

        private void LogInLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        //Method to save the data to file to be saved future use in application

        private static void Seralize(List<User> regUser)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(regUser);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\user.txt";

            WriteObjectToFile(path, jsonContent);
        }

        // Method to write data to file

        private static void WriteObjectToFile(string path, string jsonContent)
        {
            File.WriteAllText(path, jsonContent);
        }


    }
}
