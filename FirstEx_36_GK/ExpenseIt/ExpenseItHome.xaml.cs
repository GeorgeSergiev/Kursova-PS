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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Window, INotifyPropertyChanged
    {
        public ObservableCollection<string> PersonsChecked{ get; set; }
        private DateTime lastChecked;
        public DateTime LastChecked
        {
            get { return lastChecked; }
            set
            {
                lastChecked = value;
                // Извикване на PropertyChanged
                if (PropertyChanged != null)
                { 
                    PropertyChanged(this, new PropertyChangedEventArgs("LastChecked"));
                }
            }
        }

        public ExpenseItHome()
        {
            InitializeComponent();
            PersonsChecked = new ObservableCollection<string>();
            LastChecked = DateTime.Now;
            this.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // ExpenseReport dlg = new ExpenseReport();
            // dlg.Owner = this;
            // dlg.Height = this.Height;
            // dlg.Width = this.Width;
            // dlg.ShowDialog();        
            ExpenseReport expenseReport = new ExpenseReport(this.peopleListBox.SelectedItem);
            expenseReport.Show();
        }
        private void peopleListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            PersonsChecked.Add((peopleListBox.SelectedItem as System.Xml.XmlElement).Attributes["Name"].Value);
            LastChecked = DateTime.Now;
        }
    }
}
