using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFhello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListBoxItem james = new ListBoxItem(); 
            james.Content = "James"; 
            peopleListBox.Items.Add(james);
            ListBoxItem david = new ListBoxItem(); 
            david.Content = "James"; 
            peopleListBox.Items.Add(david);
            peopleListBox.SelectedItem = james;
        }

        private void btnHello_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in MainGrid.Children)
            {
                if (item is TextBox)
                {
                    sb.Append(((TextBox)item).Text + ", ");
                }
            }
            if (txtName.Text.Length < 2)
            {
                MessageBox.Show("Name has less than 2 characters ");
            }
            else
            {
                MessageBox.Show("Здрасти " + sb.ToString() );
            }
            string greetingMsg; 
            greetingMsg = (peopleListBox.SelectedItem as ListBoxItem).Content.ToString();
            MessageBox.Show("Hi " + greetingMsg);
        }

        private void btnNY_Click(object sender, RoutedEventArgs e)
        {
            double n = double.Parse(txtN.Text);
            double y = double.Parse(txtY.Text);
            double result = Math.Pow(n, y);
            MessageBox.Show("n na stepen y e: " + result.ToString());
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            var msgresult = MessageBox.Show("Are you sure about that", "test", buttons);
            if (msgresult == MessageBoxResult.No || msgresult == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyMessage anotherWindow = new MyMessage(); 
            anotherWindow.Show();
            //MessageBox.Show("This is Windows Presentation Foundation!");
            //Pesho.Text = DateTime.Now.ToString();
        }
    }
}
