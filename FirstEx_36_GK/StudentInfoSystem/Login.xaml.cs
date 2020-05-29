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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            if(CRUDETest.TestUserIfEmpty())
            {
                CRUDETest.CopyTestUsers();
            }
            InitializeComponent();
        }
        public static void ErrHandler(string errorMsg)
        {
            MessageBox.Show(errorMsg);
        }

        private void btn_click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();
            User user = null;
            LoginValidation login = new LoginValidation(username, password, ErrHandler);
            if (login.ValidateUserInput(ref user))
            {
                Student student = StudentValidation.GetStudentDataByUser(user);
                MainWindow anotherWindow = new MainWindow();
                anotherWindow.Vm.ShowStudentData = student;
                anotherWindow.Show();
                this.Close();
            }
        }
    }
}
