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
    /// Interaction logic for ForgottenPasswordView.xaml
    /// </summary>
    public partial class ForgottenPasswordView : Page
    {
        // Load methods on page open

        public ForgottenPasswordView()
        {
            InitializeComponent();
        }

        // Method to update user password

        private void UpdatePasswordButton_Click(object sender, RoutedEventArgs e)
        {

            if (ForgottenPasswordUsernameTextBox.Text == string.Empty || ForgottenPasswordSecurityQuestionTextBox.Text == string.Empty
                || UpdatePasswordPwdBox.Password == string.Empty)
            {
                MessageBox.Show("Please enter your credentials and a new password to use");
            }

            else
            {
                // Loop through the RegisteredUsers list

                foreach (var regUserData in RegisteredUsers.Users)
                {

                    // Validating users entered credentials to data within RegisteredUsers list

                    if (regUserData.Username.Equals(ForgottenPasswordUsernameTextBox.Text)
                        && regUserData.SecurityQuestion.Equals(ForgottenPasswordSecurityQuestionTextBox.Text))
                    {
                        // Update password data with new password entered

                        regUserData.Password = UpdatePasswordPwdBox.Password;

                        // Save the new data to file

                        Seralize(RegisteredUsers.Users);
                        MessageBox.Show("Password updated to: " + regUserData.Password);
                        return;
                    }
                }
                MessageBox.Show("Could not find account with provided credentials", "Update Password Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Opens HomepageView

        private void LogInLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        //Method to save the data to file to be saved future use in application

        private static void Seralize(List<User> regUsers)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(regUsers);

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
