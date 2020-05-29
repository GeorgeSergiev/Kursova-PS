using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UserLogin;

namespace StudentInfoSystem
{
    class MainFormVM : ObservableObject
    {
        private MainWindow window;
        private Student student;
        public MainFormVM(MainWindow window)
        {
            this.window = window;
        }
        public Student ShowStudentData
        {
            set
            {
                if (value != null)
                {
                    CurrentStudent = value;
                }
                else
                {
                    ClearFields();
                    makeInactive();
                }
            }
        }
        public Student CurrentStudent
        {
            get { return student; }
            set
            {
                student = value;
                RaisePropertyChangedEvent("CurrentStudent");
            }
        }

        public ICommand ClearInputsCommand
        {
            get { return new Command(_=>ClearFields()); }
        }

        public ICommand PopulateInputsCommand
        {
            get { return new Command(_ =>FillsData()); }
        }

        public ICommand DisableInputsCommand
        {
            get { return new Command(_ =>makeInactive()); }
        }

        public void ClearFields()
        {
            CurrentStudent = null;
        }

        private void FillsData()
        {
            User user = UserData.TestUsers[0];
            student = StudentValidation.GetStudentDataByUser(user);
            ShowStudentData = student;
        }

        public void makeInactive()
        {
            foreach (var item in window.MainGrid.Children)
            {
                (item as UIElement).IsEnabled = false;
            }
        }
        public void makeActive()
        {
            foreach (Control item in window.MainGrid.Children)
            {
                item.IsEnabled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control item in window.MainGrid.Children)
            {
                item.IsEnabled = false;
            }
        }
    }
}
