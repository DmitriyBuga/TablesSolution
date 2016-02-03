using ConnectTable.Model;
using ConnectTable.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ConnectTable.View
{
    /// <summary>
    /// Interaction logic for ViewFilter.xaml
    /// </summary>
    public partial class ViewFilter : Window
    {
        public ObservableCollection<RowFilterTable> table { get; set; }
        ViewModelSetFilter model { get; set; }
        public ViewFilter(List<string> listFields)
        {
            //CreateGrid();
            
            //CreateFilterList();
            InitializeComponent();
            model = new ViewModelSetFilter(listFields);

            DataContext = model;
            dataGrid.ItemsSource = model.table;
            Messenger.Default.Register<string>(this, "SetFilter", table =>
            {
                this.table = model.table;
                Close();
            }
            );
            Messenger.Default.Register<string>(this, "Close", table =>
            {
                Close();
            }
            );
            //listView.ItemsSource = model.table;
        }
        
    }
}
