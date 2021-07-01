using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace w1640643CW2.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public string EmailAddress { get; set; }

        public Contact(string firstName = "", string lastName = "", string number = "", string address = "")
        {
            FirstName = firstName;
            LastName = lastName;
            Number = number;
            EmailAddress = address;
        }
    }
}
