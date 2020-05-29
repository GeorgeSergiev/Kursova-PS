using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> _testUsers;

        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        private static void ResetTestUserData() 
        {
            _testUsers = new List<User>(3);
            for (int i = 0; i < 3; i++) {
                _testUsers.Add(new User());
            }
            _testUsers[0].Username = "Georgi";
            _testUsers[0].FacNum = "121217109";
            _testUsers[0].Password = PasswordHash.Hash("123456");
            _testUsers[0].UserRole = UserRoles.ADMIN;
            _testUsers[0].Created = DateTime.Now;
            _testUsers[0].DateActive = DateTime.MaxValue;

            _testUsers[1].Username = "Pencho";
            _testUsers[1].FacNum = "121217888";
            _testUsers[1].Password = PasswordHash.Hash("123456");
            _testUsers[1].UserRole = UserRoles.STUDENT;
            _testUsers[1].Created = DateTime.Now;
            _testUsers[1].DateActive = DateTime.MaxValue;

            _testUsers[2].Username = "Atanas";
            _testUsers[2].FacNum = "121217898";
            _testUsers[2].Password = PasswordHash.Hash("123456");
            _testUsers[2].UserRole = UserRoles.STUDENT;
            _testUsers[2].Created = DateTime.Now;
            _testUsers[2].DateActive = DateTime.MaxValue;
        }
        public static User IsUserPassCorrect(string username, string password)
        {
            //foreach (User user in TestUsers) 
            //{
            //    if (user.Username.Equals(username) && user.Password.Equals(password))
            //    {
            //        return user;
            //    }
            //}
            //return null;
            UserLoginContext context = new UserLoginContext();

            User result =
            (from st in context.Users
             where st.Username == username
             select st).FirstOrDefault();
            if (result == null)
            {
                return null;
            }
            if (!PasswordHash.ComparePass(password, result.Password))
            {
                return null;
            }
            return result;
        }
        public static void SetUserActiveTo(string username, DateTime newDateActive)
        {
            //foreach (User user in TestUsers)
            //{
            //    if (user.Username == username)
            //    {
            //        user.DateActive = newDateActive;
            //        Logger.LogActivity("Change activity of " + username);
            //    }
            //}
            UserLoginContext context = new UserLoginContext();
            User usr =
            (from u in UserData.TestUsers
             where u.Username == username
             select u).First();
            usr.DateActive = newDateActive;
            Logger.LogActivity("Change activity of " + username);
            context.SaveChanges();
        }

        public static void AssignUserRole(string username, UserRoles newUserRole)
        {
            //foreach (User user in TestUsers)
            //{
            //    if (user.Username == username)
            //    {
            //        user.UserRole = newUserRole;
            //        Logger.LogActivity("Change role of " + username);
            //    }
            //}
            UserLoginContext context = new UserLoginContext();
            User usr =
            (from u in UserData.TestUsers
             where u.Username == username
             select u).First();
            usr.UserRole = newUserRole;
            context.SaveChanges();
        }


        
    }
}
