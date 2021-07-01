using System;
using System.Collections.Generic;
using System.Text;

namespace w1640643CW2.Models
{
   public class BusinessContact : Contact
    {
        public string ContactBusinessName { get; set; }
        public string ContactLocation { get; set; }
        public string ContactPostcode { get; set; }
    }
}
