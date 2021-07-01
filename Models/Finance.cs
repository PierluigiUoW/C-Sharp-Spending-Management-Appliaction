using System;
using System.Collections.Generic;
using System.Text;

namespace w1640643CW2.Models
{
    public class Finance
    {
        public string FinanceName { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string FinanceDescription { get; set; }
        public string FinanceType { get; set; }
        public string FinanceContact { get; set; }
        public bool typeIsIncome { get; set; }
        public bool typeIsExpense { get; set; }

        public Finance(string name = "", decimal amount = 0, string description = "", string contact = "", string type = "", bool income = false, bool expense = false)
        {
            FinanceName = name;
            Amount = amount;
            FinanceDescription = description;
            FinanceContact = contact;
            FinanceType = type;
            typeIsIncome = income;
            typeIsExpense = expense;
        }

    }

}
