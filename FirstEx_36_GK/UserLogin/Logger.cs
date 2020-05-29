using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    static public class Logger
    {
        static string filepath = "../../test.txt";
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + LoginValidation.CurrentUserUsername + ";" + LoginValidation.CurrentUserRole + ";" + activity + Environment.NewLine; 
            currentSessionActivities.Add(activityLine);
            File.AppendAllText(filepath, activityLine);
            CopyLogs();
        }

        static public string GetCurrentSessionActivities() 
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in currentSessionActivities)
            {
                sb.AppendLine(s);
            }
            return  sb.ToString();
        }

        static public string GetLogFile() 
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr = new StreamReader(filepath);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                sb.AppendLine(line);
            }
            sr.Close();
            return sb.ToString();
        }

        static void CopyLogs()
        {          
            UserLoginContext context = new UserLoginContext();            
            Logs log = new Logs();
            log.Activity = currentSessionActivities.Last();
            context.Logs.Add(log);
            context.SaveChanges();
        }


    }
}
