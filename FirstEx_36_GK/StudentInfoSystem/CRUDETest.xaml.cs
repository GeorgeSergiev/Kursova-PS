using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for CRUDETest.xaml
    /// </summary>
    public partial class CRUDETest : Window
    {
        public CRUDETest()
        {
            InitializeComponent();
        }
        public bool TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();
            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();
            if (countStudents == 0)
            {
                return true;
            }
            return false;
        }

        void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();
            foreach (Student st in StudentData.TestStudent)
            {
                context.Students.Add(st);
            }
            context.SaveChanges();
        }

        private void isEmpTy(object sender, RoutedEventArgs e)
        {
            if (TestStudentsIfEmpty())
            {
                CopyTestStudents();
            }
            MessageBox.Show(TestStudentsIfEmpty().ToString());
        }

        public static bool TestUserIfEmpty()
        {
            UserLoginContext context = new UserLoginContext();
            IEnumerable<User> queryUsers = context.Users;
            int countUsers = queryUsers.Count();
            if (countUsers == 0)
            {
                return true;
            }
            return false;
        }

        public static void CopyTestUsers()
        {
            UserLoginContext context = new UserLoginContext();
            foreach (User st in UserData.TestUsers)
            {
                context.Users.Add(st);
            }
            context.SaveChanges();
        }

        private void isEmpTyUsers(object sender, RoutedEventArgs e)
        {
            if (TestUserIfEmpty())
            {
                CopyTestUsers();
            }
            MessageBox.Show(TestUserIfEmpty().ToString());
        }
    }
}
