using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using w1640643CW2.Models;

namespace w1640643CW2
{
    class JSON
    {
        public string SeralizeList(List<User> regUser)
        {
            var seralizedRegUsers = JsonConvert.SerializeObject(regUser, Formatting.Indented);
            return seralizedRegUsers;
        }

        public string SeralizeList(List<Contact> contact)
        {
            var seralizeContactDetails = JsonConvert.SerializeObject(contact, Formatting.Indented);
            return seralizeContactDetails;
        }

        //public string SeralizeList(List<BusinessContact> businessContact)
        //{
        //    var seralizeContactDetails = JsonConvert.SerializeObject(businessContact, Formatting.Indented);
        //    return seralizeContactDetails;
        //}

        public string SeralizeList(List<Finance> finance)
        {
            var seralizeContactDetails = JsonConvert.SerializeObject(finance, Formatting.Indented);
            return seralizeContactDetails;
        }

        public string SeralizeList(List<Prediction> prediction)
        {
            var seralizeContactDetails = JsonConvert.SerializeObject(prediction, Formatting.Indented);
            return seralizeContactDetails;
        }

        public string SeralizeList(List<Report> report)
        {
            var seralizeContactDetails = JsonConvert.SerializeObject(report, Formatting.Indented);
            return seralizeContactDetails;
        }

        public List<User> DeserializeList(string json)
        {
            RegisteredUsers.Users = JsonConvert.DeserializeObject<List<User>>(json);
            return RegisteredUsers.Users;
        }

        public List<Contact> DeserializeListContact(string json)
        {
            ContactDetails.contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
            return ContactDetails.contacts;
        }

        //public List<BusinessContact> DeserializeListBusinessContact(string json)
        //{
        //    ContactDetails.BusinessContactDetails = JsonConvert.DeserializeObject<List<BusinessContact>>(json);
        //    return ContactDetails.BusinessContactDetails;
        //}

        public List<Finance> DeserializeListFinance(string json)
        {
            FinanceDetails.Finances = JsonConvert.DeserializeObject<List<Finance>>(json);
            return FinanceDetails.Finances;
        }

        public List<Prediction> DeserializeListPrediction(string json)
        {
            //PredictionDetails.Prediction = JsonConvert.DeserializeObject<List<Prediction>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            PredictionDetails.Prediction = JsonConvert.DeserializeObject<List<Prediction>>(json);
            return PredictionDetails.Prediction;
        }

        public List<Report> DeserializeListReport(string json)
        {
            //PredictionDetails.Prediction = JsonConvert.DeserializeObject<List<Prediction>>(json, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            Reports.ReportDetails = JsonConvert.DeserializeObject<List<Report>>(json);
            return Reports.ReportDetails;
        }
    }
}
