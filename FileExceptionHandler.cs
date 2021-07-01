using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace w1640643CW2
{
    // Class to handle FileNotFound exception 
    public class FileExceptionHandler
    {

        // When called, if the file path does not exist, or is not found, create a new file with the path name,
        // with default text of [] ensuring computer knows this is a list used for saving and reading JSON to and from

        public void UserFileExceptionHandler()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\user.txt";

            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);

                sw.WriteLine("[]");
                sw.Close();
            }
        }

        public void ContactFileExceptionHandler()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\contacts.txt";

            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);

                sw.WriteLine("[]");
                sw.Close();
            }
        }

        public void FinanceFileExceptionHandler()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\finances.txt";

            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);

                sw.WriteLine("[]");
                sw.Close();
            }
        }

        public void PredictionFileExceptionHandler()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\prediction.txt";

            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);

                sw.WriteLine("[]");
                sw.Close();
            }
        }

        public void ReportFileExceptionHandler()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\report.txt";

            if (!File.Exists(path))
            {
                StreamWriter sw = new StreamWriter(path);

                sw.WriteLine("[]");
                sw.Close();
            }
        }

    }
}
