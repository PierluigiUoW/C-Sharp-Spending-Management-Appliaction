using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using w1640643CW2.Models;

namespace w1640643CW2.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Page
    {

        // Load methods when page is opened
        public RegisterView()
        {
            InitializeComponent();
        }

        // Event handler for if signup button is clicked
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UsernameTextBox.Text == string.Empty || FirtnameTextBox.Text == string.Empty || LastnameTextBox.Text == string.Empty
                    || EmailAddressTextBox.Text == string.Empty || PasswordPwdBox.Password == string.Empty || SecurityQuestionResponseTextBox.Text == string.Empty)
                {
                    MessageBox.Show("Please fill in required credentials in order to create an account");
                }

                else
                {
                    // Loop through RegistedUsers list
                    foreach (var regUserData in RegisteredUsers.Users)
                    {
                        // Valdiating if the user already exists, if true, display error message and stop process
                        if (regUserData.EmailAddress.Equals(EmailAddressTextBox.Text) || regUserData.Username.Equals(UsernameTextBox.Text))
                        {
                            MessageBox.Show("Account Details provided already exist", "Registration Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    MessageBox.Show("Account successfully created!");

                    // If entered details do not already exist in RegisterdUsers list, create a new user object with the users input
                    // and add this user object to the RegisteredUsers list
                    User newUser = new User();

                    newUser.Username = UsernameTextBox.Text;
                    newUser.Firstname = FirtnameTextBox.Text;
                    newUser.Lastname = LastnameTextBox.Text;
                    newUser.EmailAddress = EmailAddressTextBox.Text;
                    newUser.Password = PasswordPwdBox.Password;
                    newUser.SecurityQuestion = SecurityQuestionResponseTextBox.Text;

                    if (RegisteredUsers.Users == null)
                        RegisteredUsers.Users = new List<User>();

                    RegisteredUsers.Users.Add(newUser);

                    // Saving data to file
                    Seralize(RegisteredUsers.Users);
                }
            }

            catch (NullReferenceException ex)
            {
                // Display messagebox error if NullReferenceException occurs
                MessageBox.Show("Exception Handled: " + ex.Message);
            }
        }

        // Opens LogInView
        private void LogInLabel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new LogInView());
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
