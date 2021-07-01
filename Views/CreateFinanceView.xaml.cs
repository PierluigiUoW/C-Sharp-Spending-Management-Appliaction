using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using w1640643CW2.Models;

namespace w1640643CW2.Views
{
    /// <summary>
    /// Interaction logic for CreateFinanceView.xaml
    /// </summary>
    public partial class CreateFinanceView : Page
    {
        // boolean to check if records are saved or not, initialised to false

        bool isFormSaved = false;

        // Dictionary used, for its fast look up ability due to using a key, set as string, value set as object of Finance

        Dictionary<string, Finance> finances = new Dictionary<string, Finance>();

        // Load methods when page is opened

        public CreateFinanceView()
        {
            InitializeComponent();
            //InitialStartUp();
        }

        //Method to save the data to file to be saved future use in application

        private static void Seralize(List<Finance> finance)
        {
            JSON json = new JSON();

            string jsonContent = json.SeralizeList(finance);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\finances.txt";

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

            finances.Clear();

            // Clears all the components for DynamicFinanceControl stackpanel

            DynamicFinanceControl.Children.Clear();
        }

        // Method used to be build and rebuild the form

        private void RebuildForm()
        {
            // Clears all the components for DynamicFinanceControl stackpanel

            DynamicFinanceControl.Children.Clear();

            // Allow text in FinanceAmount textbox to be used as a integer variable

            if (int.TryParse(FinanceAmount.Text, out int financeAmount))
            {
                // Loop, while i is less than finaceAmount

                for (int i = 0; i < financeAmount; i++)
                {
                    // Increment financeID by 1

                    var financeID = i + 1;

                    // Call CreateFinanceList method, pass financeID varialbe formatted as a string

                    CreateFinanceList(financeID.ToString());
                }
                if (financeAmount < 1)
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

        private void CreateFinanceList(string id)
        {
            // Create a stackpanel
            StackPanel stackPanel = new StackPanel();

            // Create and set properties of label
            var label = new Label();

            // Label content is set to the incremented id
            label.Content = $"Finance: {id}";
            label.FontWeight = FontWeights.Bold;
            label.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

            // Add these to the stackpanel
            stackPanel.Children.Add(label);

            // If the form is saved, the UI will look as followed
            if (isFormSaved)
            {

                // Create the required labels and set their properties

                var label1 = new Label();
                label1.Content = "Finance Name: ";
                label1.MinWidth = 100;
                label1.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var contentLabel1 = new Label();
                contentLabel1.MinWidth = 100;
                contentLabel1.Content = finances[id].FinanceName;

                contentLabel1.FontWeight = FontWeights.Bold;
                contentLabel1.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var label2 = new Label();
                label2.Content = "Finance Amount: ";
                label2.MinWidth = 100;
                label2.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var contentLabel2 = new Label();
                contentLabel2.MinWidth = 100;
                contentLabel2.Content = finances[id].Amount;
                contentLabel2.FontWeight = FontWeights.Bold;
                contentLabel2.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var label3 = new Label();
                label3.Content = "Finance Description: ";
                label3.MinWidth = 100;
                label3.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var contentLabel3 = new Label();
                contentLabel3.MinWidth = 100;
                contentLabel3.Content = finances[id].FinanceDescription;
                contentLabel3.FontWeight = FontWeights.Bold;
                contentLabel3.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var label4 = new Label();
                label4.Content = "Finance Contact: ";
                label4.MinWidth = 100;
                label4.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var contentLabel4 = new Label();
                contentLabel4.MinWidth = 100;
                contentLabel4.Content = finances[id].FinanceContact;
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
                label1.MinWidth = 100;
                label1.Content = "Finance Name: ";
                label1.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var textBox1 = new TextBox();
                textBox1.MinWidth = 100;
                // A delegate is used for the event handling, includes lambda expression
                textBox1.TextChanged += (sender, e) => { TextBox1_TextChanged(sender, e, id); };

                var label2 = new Label();
                label2.MinWidth = 100;
                label2.Content = "Finance Amount: ";
                label2.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var textBox2 = new TextBox();
                textBox2.MinWidth = 100;
                // A delegate is used for the event handling, includes lambda expression
                textBox2.TextChanged += (sender, e) => { TextBox2_TextChanged(sender, e, id); };

                var label3 = new Label();
                label3.MinWidth = 100;
                label3.Content = "Finance Description: ";
                label3.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                var textBox3 = new TextBox();
                textBox3.MinWidth = 100;
                // A delegate is used for the event handling, includes lambda expression
                textBox3.TextChanged += (sender, e) => { TextBox3_TextChanged(sender, e, id); };

                var label4 = new Label();
                label4.MinWidth = 100;
                label4.Content = "Contact: ";
                label4.Style = (Style)(Application.Current.Resources["SecondaryLabelStyle"]);

                // Create a combo box
                var comboBox = new ComboBox();

                // Loop through the ContactDetails list
                foreach (var item in ContactDetails.contacts)
                {
                                                                                // Add all the ContactDetails list data of firstname and lastname to the combo box
                    comboBox.Items.Add(item.FirstName + " " + item.LastName);
                }

                // A delegate is used for the event handling, includes lambda expression
                comboBox.SelectionChanged += (sender, e) => { Combobox_SelectionChanged(sender, e, id); };

                // Add all the UI elements to the stackpanel
                stackPanel.Children.Add(label1);
                stackPanel.Children.Add(textBox1);

                stackPanel.Children.Add(label2);
                stackPanel.Children.Add(textBox2);

                stackPanel.Children.Add(label3);
                stackPanel.Children.Add(textBox3);

                stackPanel.Children.Add(label4);
                stackPanel.Children.Add(comboBox);
            }

            // Create two radio buttons
            ToggleButton statusButton1 = new RadioButton();
            ToggleButton statusButton2 = new RadioButton();

            // Set the properties of the first radio button, so that it indicates this is for creating a finance record of type Income
            statusButton1.Content = "Income";
            statusButton1.Width = 100;
            statusButton1.HorizontalAlignment = HorizontalAlignment.Center;

            // Set the properties of the first radio button, so that it indicates this is for creating a finance record of type Expense
            statusButton2.Content = "Expense";
            statusButton2.Width = 100;
            statusButton2.HorizontalAlignment = HorizontalAlignment.Center;

            statusButton1.IsChecked = finances[id].typeIsIncome;
            statusButton2.IsChecked = finances[id].typeIsExpense;

            // If formed is saved
            if (isFormSaved)
            {
                // Disable the radio buttons so they cannot be modified
                statusButton1.IsEnabled = false;
                statusButton2.IsEnabled = false;
            }

            // Delegates used for the event handling, includes lambda expression
            statusButton1.Click += (sender, e) => { StatusButtonClicked(sender, e, id); };
            statusButton2.Click += (sender, e) => { StatusButtonClicked(sender, e, id); };

            // Add the radio buttons to the stackpanel
            stackPanel.Children.Add(statusButton1);
            stackPanel.Children.Add(statusButton2);

            // Add the stackpanel to the DynamicFinanceControl stackpanel created within CreateFinanceView XAML 
            DynamicFinanceControl.Children.Add(stackPanel);
        }

        //Selection Changed Event handler for combo box
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e, string id)
        {
            // Cast event handler sender as ComboBox
            var comboBox = (ComboBox)sender;

            // FinanceContact value in key posiition of finances, is set to selected item in combo box, formated as string
            finances[id].FinanceContact = comboBox.SelectedItem.ToString();
        }

        //Text Changed Event handler for finance description text box
        private void TextBox3_TextChanged(object sender, TextChangedEventArgs e, string id)
        {
            // Cast event handler sender as textBox
            var textBox = (TextBox)sender;

            // FinanceDescription value in key posiition of finances, is set to textbox text
            finances[id].FinanceDescription = textBox.Text;
        }

        //Text Changed Event handler for finance amount text box
        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e, string id)
        {
            // Cast event handler sender as textBox
            var textBox = (TextBox)sender;

            // Allow text in textbox  to be used as a integer variable
            decimal.TryParse(textBox.Text, out decimal financeAmount);

            // financeAmount value in key posiition of finances, is set to Amount
            finances[id].Amount = financeAmount;
        }

        //Text Changed Event handler for finance name text box
        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e, string id)
        {
            // Cast event handler sender as textBox
            var textBox = (TextBox)sender;

            // FinanceName value in key posiition of finances, is set to textBox text
            finances[id].FinanceName = textBox.Text;
        }

        //Clicked Event handler for radio buttons
        private void StatusButtonClicked(object sender, RoutedEventArgs e, string id)
        {
            // Cast event handler sender as ToggleButton
            var toggleButton = (ToggleButton)sender;

            // Sets the default value of if radio button is checked as false
            var isButtonChecked = toggleButton.IsChecked.GetValueOrDefault(false);

            // If the radio button which is selected is the Income radio button
            if (toggleButton.Content.ToString() == "Income")
            {
                // fiancetype value in key posiition of finances, is set to Income
                finances[id].FinanceType = "Income";

                // Sets the value of typeIsIncome to true
                finances[id].typeIsIncome = isButtonChecked;
                // Sets the value of typeIsExpense to false
                finances[id].typeIsExpense = !isButtonChecked;
            }

            else
            {
                // fiancetype value in key posiition of finances, is set to Expense
                finances[id].FinanceType = "Expense";

                // Sets the value of typeIsExpense to true
                finances[id].typeIsExpense = isButtonChecked;
                // Sets the value of typeIsIncome to false
                finances[id].typeIsIncome = !isButtonChecked;
            }
        }

        // Method used to add values to the finances Dictionary
        private void CreateList()
        {
            // Allow text in FinanceAmount textbox to be used as a integer variable
            int.TryParse(FinanceAmount.Text, out int financeAmount);

            // Loop when i is less than financeAmount
            for (int i = 0; i < financeAmount; i++)
            {

                // Increment id by 1
                var id = i + 1;
                // Create a new finance object with id formatted as string
                var finance = new Finance(id.ToString());

                //Adds the finance to the Dictionary, to its corresponding key
                finances.Add(id.ToString(), finance);
            }
        }

        // Click Event handler for Save Button

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // sets isFormSaved to true

            isFormSaved = true;

            // Reset button visibility, initially hidden, is set to be visislbe

            ResetButton.Visibility = Visibility.Visible;

            // Calls RebuildForm method to rebuild the form
            RebuildForm();


            // Loops through the Dictionary
            foreach (var item in finances)
            {
                // Sets the Dictionary CreationDateTime value for Finance objects to the current data and time
                item.Value.CreationDateTime = DateTime.Now;
            }

            MessageBox.Show("Finance record(s) saved!");

            // Adds the Dictionary and its Finance object values to the FinanceDetails list
            FinanceDetails.Finances.AddRange(finances.Values);

            // Save FinanceDetails list data to file
            Seralize(FinanceDetails.Finances);
        }

        // Opens FinanceView 
        private void GoBackLabel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new FinanceView());
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
