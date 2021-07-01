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
    /// Interaction logic for CreateContactView.xaml
    /// </summary>
    public partial class CreateContactView : Page
    {
        // boolean to check if records are saved or not, initialised to false
        bool isFormSaved = false;

        // Dictionary used, for its fast look up ability due to using a key, set as string, value set as object of Contact
        Dictionary<string, Contact> contacts = new Dictionary<string, Contact>();

        // Load methods when page is opened
        public CreateContactView()
        {
            InitializeComponent();
            //InitialStartUp();
        }

        //Method to save the data to file to be saved future use in application
        private static void Seralize(List<Contact> contacts)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(contacts);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\contacts.txt";

            WriteObjectToFile(path, jsonContent);
        }

        // Method to write data to file
        private static void WriteObjectToFile(string path, string jsonContent)
        {
            File.WriteAllText(path, jsonContent);
        }

        // Click Event handler for Submit Button
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            // Methods to call
            ClearAlLData();
            CreateList();
            RebuildForm();

            // Save button, initially hidden, is now set to visible
            SaveButton.Visibility = Visibility.Visible;
        }

        // Method to clear all data
        private void ClearAlLData()
        {
            // Removes all keys and values from finances Dictionary
            contacts.Clear();
            // Clears all the components for DynamicFinanceControl stackpanel
            DynamicContactControl.Children.Clear();
        }

        // Method used to be build and rebuild the form
        private void RebuildForm()
        {
            // Clears all the components for DynamicFinanceControl stackpanel
            DynamicContactControl.Children.Clear();

            // Allow text in ContactAmount textbox to be used as a integer variable
            if (int.TryParse(ContactAmount.Text, out int contactAmount))
            {
                // Loop, while i is less than finaceAmount
                for (int i = 0; i < contactAmount; i++)
                {
                    // Increment financeID by 1
                    var contactID = i + 1;
                    // Call CreateContactList method, pass financeID varialbe formatted as a string
                    CreateContactList(contactID.ToString());
                }

                if (contactAmount < 1)
                {
                    MessageBox.Show("Please enter numeric value greater than 0");
                }
            }
            else
            {
                MessageBox.Show("Please enter numeric value");
            }
        }

        // Method to create the UI, allows for dynamic creation
        private void CreateContactList(string id)
        {
            // Create a stackpanel
            var stackPanel = new StackPanel();

            // Create and set properties of label
            var label = new Label();
            // Label content is set to the incremented id
            label.Content = $"Contact: {id}";
            label.FontWeight = FontWeights.Bold;
            label.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

            // Add these to the stackpanel
            stackPanel.Children.Add(label);

            // If the form is saved, the UI will look as followed
            if (isFormSaved)
            {
                // Create the required labels and set their properties
                var label1 = new Label();
                label1.Content = "First Name";
                label1.MinWidth = 100;
                label1.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var contentLabel1 = new Label();
                contentLabel1.MinWidth = 100;
                //contentLabel1.Content = contact.FirstName;
                contentLabel1.Content = contacts[id].FirstName;
                contentLabel1.FontWeight = FontWeights.Bold;
                contentLabel1.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var label2 = new Label();
                label2.Content = "Last Name";
                label2.MinWidth = 100;
                label2.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var contentLabel2 = new Label();
                contentLabel2.MinWidth = 100;
                contentLabel2.Content = contacts[id].LastName;
                contentLabel2.FontWeight = FontWeights.Bold;
                contentLabel2.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var label3 = new Label();
                label3.Content = "Number";
                label3.MinWidth = 100;
                label3.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var contentLabel3 = new Label();
                contentLabel3.MinWidth = 100;
                contentLabel3.Content = contacts[id].Number;
                contentLabel3.FontWeight = FontWeights.Bold;
                contentLabel3.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var label4 = new Label();
                label4.Content = "Email Address";
                label4.MinWidth = 100;
                label4.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var contentLabel4 = new Label();
                contentLabel4.MinWidth = 100;
                contentLabel4.Content = contacts[id].EmailAddress;
                contentLabel4.FontWeight = FontWeights.Bold;
                contentLabel4.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                // Add all the UI elements to the stackpanel
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(contentLabel1);

                stackPanel.Children.Add(label2);
                stackPanel.Children.Add(contentLabel2);

                stackPanel.Children.Add(label3);
                stackPanel.Children.Add(contentLabel3);

                stackPanel.Children.Add(label4);
                stackPanel.Children.Add(contentLabel4);
            }

            // if form is not saved, display the UI as followed
            else
            {
                // Create the required labels and textboxes and set their proeprties
                var label1 = new Label();
                label1.Content = "First Name";
                label1.MinWidth = 100;
                label1.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var textBox1 = new TextBox();
                textBox1.MinWidth = 100;
                // A delegate is used for the event handling, includes lambda expression
                textBox1.TextChanged += (sender, e) => { TextBox1_TextChanged(sender, e, id); };

                var label2 = new Label();
                label2.Content = "Last Name";
                label2.MinWidth = 100;
                label2.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var textBox2 = new TextBox();
                textBox2.MinWidth = 100;
                textBox2.TextChanged += (sender, e) => { TextBox2_TextChanged(sender, e, id); };

                var label3 = new Label();
                label3.Content = "Number";
                label3.MinWidth = 100;
                label3.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var textBox3 = new TextBox();
                textBox3.MinWidth = 100;
                //A delegate is used for the event handling, includes lambda expression
                textBox3.TextChanged += (sender, e) =>
                {
                    TextBox3_TextChanged(sender, e, id);
                };
                textBox1.Text = contacts[id].Number;

                var label4 = new Label();
                label4.Content = "Email Address";
                label4.MinWidth = 100;
                label4.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var textBox4 = new TextBox();
                textBox4.MinWidth = 100;
                // A delegate is used for the event handling, includes lambda expression
                textBox4.TextChanged += (sender, e) => { TextBox4_TextChanged(sender, e, id); };

                // Add all the UI elements to the stackpanel
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(textBox1);

                stackPanel.Children.Add(label2);
                stackPanel.Children.Add(textBox2);

                stackPanel.Children.Add(label3);
                stackPanel.Children.Add(textBox3);

                stackPanel.Children.Add(label4);
                stackPanel.Children.Add(textBox4);
            }

            // Add the stackpanel to the DynamicContactControl stackpanel created within CreateFinanceView XAML 
            DynamicContactControl.Children.Add(stackPanel);
        }

        //Text Changed Event handler for email address text box
        private void TextBox4_TextChanged(object sender, TextChangedEventArgs e, string id)
        {
            // Cast event handler sender as textBox
            var textBox = (TextBox)sender;
            // EmailAddress value in key posiition of finances, is set to textbox text
            contacts[id].EmailAddress = textBox.Text;
        }

        ////Text Changed Event handler for number text box
        private void TextBox3_TextChanged(object sender, TextChangedEventArgs e, string id)
        {
            // Cast event handler sender as textBox
            var textBox = (TextBox)sender;

            //number value in key posiition of finances, is set to textbox text
            contacts[id].Number = textBox.Text;
        }

        //Text Changed Event handler for last name text box
        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e, string id)
        {
            // Cast event handler sender as textBox
            var textBox = (TextBox)sender;
            // Last name value in key posiition of finances, is set to textbox text
            contacts[id].LastName = textBox.Text;
        }

        //Text Changed Event handler for first name text box
        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e, string id)
        {
            // Cast event handler sender as textBox
            var textBox = (TextBox)sender;
            // First name value in key posiition of finances, is set to textbox text
            contacts[id].FirstName = textBox.Text;
        }

        // Method used to add values to the finances Dictionary
        private void CreateList()
        {
            // Allow text in FinanceAmount textbox to be used as a integer variable
            int.TryParse(ContactAmount.Text, out int contactAmount);

            // Loop when i is less than financeAmount
            for (int i = 0; i < contactAmount; i++)
            {
                // Increment id by 1
                var id = i + 1;
                // Create a new contact object with id formatted as string
                var contact = new Contact(id.ToString());

                //Adds the contact to the Dictionary, to its corresponding key
                contacts.Add(id.ToString(), contact);
            }
        }

        // Click Event handler for Save Button
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //UpdateContactDetails();

            // sets isFormSaved to true
            isFormSaved = true;
            // Reset button visibility, initially hidden, is set to be visislbe
            ResetButton.Visibility = Visibility.Visible;
            // Calls RebuildForm method to rebuild the form
            RebuildForm();

            MessageBox.Show("Contact record(s) saved!");

            // Adds the Dictionary and its contact object values to the ContactDetails list
            ContactDetails.contacts.AddRange(contacts.Values);
            // Save ContactDetails list data to file
            Seralize(ContactDetails.contacts);

        }

        // Opens ContactView 
        private void GoBackLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ContactView());
            //NavigationService.GoBack();
        }

        // Click Event handler for Reset Button
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // Sets isFormSaved to false
            isFormSaved = false;
            // Calls RebuildForm method to rebuild the form
            RebuildForm();
        }
    }
}
