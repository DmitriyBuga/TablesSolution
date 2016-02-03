using ConnectTable.Helpers;
using ConnectTable.Model;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ConnectTable.ViewModel
{
    class ViewModelSetFilter : ViewModelBase
    {
        public ObservableCollection<RowFilterTable> table { get; set; }
        public ObservableCollection<string> Operators { get; set; }
        public ViewModelSetFilter(List<string> listFields)
        {
            table = new ObservableCollection<RowFilterTable>();
            foreach (string field in listFields)
                table.Add(new RowFilterTable { fieldName = field, textValue = "", Operator = ""});
            Operators = new ObservableCollection<string>();
            Operators.Add("");
            Operators.Add("=");
            Operators.Add("!=");
            Operators.Add(">");
            Operators.Add("<");
            Operators.Add(">=");
            Operators.Add("<=");
            SetFilterUserCommand = new RelayCommand(SetFilter);
            CloseUserCommand = new RelayCommand(CloseWindow);
        }
        public RelayCommand SetFilterUserCommand { get; set; }
        public RelayCommand CloseUserCommand { get; set; }
        public void SetFilter(object parameters)
        {
            Messenger.Default.Send<string>("", "SetFilter");
        }
        public void CloseWindow(object parameters)
        {
            Messenger.Default.Send<string>("", "Close");
        }
    }
}
