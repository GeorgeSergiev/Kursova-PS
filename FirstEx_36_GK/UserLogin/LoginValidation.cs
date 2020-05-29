using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private string username;
        private string password;
        private string errormesage;
        public delegate void ActionOnError(string errorMsg);
        private ActionOnError err;

     

        public LoginValidation(string username, string password, ActionOnError err) 
        {
            this.username = username;
            this.password = password;
            this.err = err;
        }
        public static UserRoles CurrentUserRole
        {
            get;
            private set;
        }

        public static string CurrentUserUsername
        {
            get;
            private set;
        }
        
        static public bool UserLoginPossible()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string curAct = Logger.GetCurrentSessionActivities();
            string[] rows = curAct.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string row in rows)
            {  
                string[] tokens = row.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                string datestr = tokens[0];
                string error = tokens[3];
                DateTime date = DateTime.Parse(datestr);
                TimeSpan diff = date - DateTime.Now;
                if (diff.TotalMinutes < 2)
                {
                    if (dict.ContainsKey(error))
                    {
                        dict[error]++;
                        if (dict[error] >= 3)
                        {
                            Logger.LogActivity("Login limit reached");
                            return false;
                        }
                    }
                    else
                    {
                        dict.Add(error, 1);
                    }
                }
            }
            return true;
        }

        public bool ValidateUserInput(ref User user)
        {
            if (string.IsNullOrWhiteSpace(username) ||string.IsNullOrEmpty(username))
            {
                errormesage = "Username must be filled";
                CurrentUserRole = UserRoles.ANONYMOUS;
                CurrentUserUsername = "Unknown";
                err(errormesage);
                return false;
            }
            if (username.Length < 5)
            {
                errormesage = "Username must 5 or more symbols";
                CurrentUserRole = UserRoles.ANONYMOUS;
                CurrentUserUsername = "Unknown";
                err(errormesage);
                return false;
            }
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(password))
            {
                errormesage = "Password must be filled";
                CurrentUserRole = UserRoles.ANONYMOUS;
                CurrentUserUsername = "Unknown";
                err(errormesage);
                return false;
            }
            if (password.Length < 5)
            {
                errormesage = "Password must 5 or more symbols";
                CurrentUserRole = UserRoles.ANONYMOUS;
                CurrentUserUsername = "Unknown";
                err(errormesage);
                return false;
            }
            user = UserData.IsUserPassCorrect(username, password);
            if (user == null)
            {
                errormesage = "Invalid Credentials";
                CurrentUserRole = UserRoles.ANONYMOUS;
                CurrentUserUsername = "Unknown";
                err(errormesage);
                return false;
            }
                //user.FacNum = UserData.TestUser.FacNum;
                //user.Username = UserData.TestUser.Username;
                //user.Password = UserData.TestUser.Password;
                //user.UserRole = UserData.TestUser.UserRole;
            CurrentUserRole = user.UserRole;
            CurrentUserUsername = user.Username;
            Logger.LogActivity("Successful Login");
            return true;
        }
    }
}
