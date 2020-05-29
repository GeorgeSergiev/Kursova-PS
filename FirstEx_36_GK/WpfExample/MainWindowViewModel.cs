using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfExample
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand hiButtonCommand; private ICommand toggleExecuteCommand { get; set; }
        private bool canExecute = true;
        private string greeting;

        public event PropertyChangedEventHandler PropertyChanged;

        public string HiButtonContent { get { return "click to hi"; } }

        public bool CanExecute { get { return this.canExecute; } set { if (this.canExecute == value) { return; } this.canExecute = value; } }

        public ICommand ToggleExecuteCommand { get { return toggleExecuteCommand; } set { toggleExecuteCommand = value; } }

        public ICommand HiButtonCommand { get { return hiButtonCommand; } set { hiButtonCommand = value; } }

        public MainWindowViewModel() { HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute); toggleExecuteCommand = new RelayCommand(ChangeCanExecute); }

        public void ShowMessage(object obj)
        {
            //it is good we do this with binding to some control 
            Greeting = DateTime.Now.ToLongTimeString() + ": " + obj.ToString();
        }
        public void OnPropChanged(string name) 
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        public string Greeting 
        { 
            get { return greeting; } 
            set 
            {
                if (Greeting == value)
                {
                    return;
                }
                greeting = value;
                OnPropChanged(nameof(Greeting));
            } 
        }

        public void ChangeCanExecute(object obj) { canExecute = !canExecute; }

    }
}
