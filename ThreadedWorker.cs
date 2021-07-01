using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using w1640643CW2.Models;

namespace w1640643CW2
{
    // cLASS CREATED IN ATTEMP TO DO THREADING JSON SERALIZE AND DESERALIZE METHODS (FILE WRITING)
    //CODE NOT COMMENTED OUT DUE TO CALLS TO METHODS WITHIN ThreadedWorker CLASS ARE COMMENTED OUT

    // Thread class used to save and load JSON data on a different thread
    public class ThreadedWorker
    {

        private Thread thread1;
        private Thread thread2;
        private Thread thread3;
        private Thread thread4;
        private Thread thread5;

        // Used to lock and unlock threads
        private static object LockingThread = "";

        public ThreadedWorker()
        {
            thread1 = new Thread(new ThreadStart(Deseralize));
            thread1.Start();

            thread2 = new Thread(new ThreadStart(DeseralizeContacts));
            thread2.Start();

            thread3 = new Thread(new ThreadStart(DeseralizePrediction));
            thread3.Start();

            thread4 = new Thread(new ThreadStart(DeseralizeReport));
            thread4.Start();

            thread5 = new Thread(new ThreadStart(DeseralizeFinances));
            thread5.Start();
        }

        public void Deseralize()
        {
            lock (LockingThread)
            {
                JSON json = new JSON();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\user.txt";

                string jsonContent = ReadFromFile(path);

                RegisteredUsers.Users = json.DeserializeList(jsonContent);
            }
        }

        public void DeseralizeContacts()
        {
            lock (LockingThread)
            {
                JSON json = new JSON();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\contacts.txt";

                string jsonContent = ReadFromFile(path);

                ContactDetails.contacts = json.DeserializeListContact(jsonContent);
            }
        }

        public void DeseralizePrediction()
        {
            lock (LockingThread)
            {
                JSON json = new JSON();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\prediction.txt";

                string jsonContent = ReadFromFile(path);

                PredictionDetails.Prediction = json.DeserializeListPrediction(jsonContent);
            }

        }

        public void DeseralizeReport()
        {
            lock (LockingThread)
            {
                JSON json = new JSON();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\report.txt";

                string jsonContent = ReadFromFile(path);

                Reports.ReportDetails = json.DeserializeListReport(jsonContent);
            }
        }

        public void DeseralizeFinances()
        {
            lock (LockingThread)
            {
                JSON json = new JSON();

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\finances.txt";

                string jsonContent = ReadFromFile(path);

                FinanceDetails.Finances = json.DeserializeListFinance(jsonContent);
            }
        }


        private static string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        public void Seralize(List<Contact> contacts)
        {
            lock (LockingThread)
            {
                JSON json = new JSON();

                string jsonContent = json.SeralizeList(contacts);

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\contacts.txt";

                WriteObjectToFile(path, jsonContent);
            }
        }

        public void Seralize(List<Finance> finance)
        {
            lock (LockingThread)
            {
                JSON json = new JSON();

                string jsonContent = json.SeralizeList(finance);

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\finances.txt";

                WriteObjectToFile(path, jsonContent);
            }
        }

        public void Seralize(List<User> regUser)
        {
            lock (LockingThread)
            {

                JSON json = new JSON();

                string jsonContent = json.SeralizeList(regUser);

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\user.txt";

                WriteObjectToFile(path, jsonContent);
            }
        }

        public void Seralize(List<Prediction> prediction)
        {
            lock (LockingThread)
            {
                JSON json = new JSON();

                string jsonContent = json.SeralizeList(prediction);

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\prediction.txt";

                WriteObjectToFile(path, jsonContent);
            }
        }

        public void Seralize(List<Report> reports)
        {
            lock (LockingThread)
            {
                JSON json = new JSON();

                string jsonContent = json.SeralizeList(reports);

                string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\report.txt";

                WriteObjectToFile(path, jsonContent);
            }
        }

        private static void WriteObjectToFile(string path, string jsonContent)
        {
            File.WriteAllText(path, jsonContent);
        }

    }
}
