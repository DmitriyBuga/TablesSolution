using ConnectTable.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    /// Логика взаимодействия для ConnectWindow.xaml
    /// </summary>
    
    public partial class ConnectWindow : Window
    {
        public ViewModelConnect model { get; set; }
        public void InitModel()
        {
            model = new ViewModelConnect();
        }
        public ConnectWindow()
        {
            
            InitializeComponent();

            Messenger.Default.Register<bool>(this, "EnableBtnConnect", x =>
            {
                btnTestConnect.IsEnabled = x;
            }
            );
            Messenger.Default.Register<bool>(this, "EnableSelectDataBase", x =>
            {
                cmbDatabases.IsEnabled = x;
            }
            );
            Messenger.Default.Register<bool>(this, "EnableSelectTable", x =>
            {
                cmbTables.IsEnabled = x;
            }
            );
            Messenger.Default.Register<bool>(this, "EnableOpenButton", x =>
             {
                 btnOpenTable.IsEnabled = x;
             }
            );
            Messenger.Default.Register<ViewModelConnect>(this, "OpenTable", x =>
            {
                model = x;
                Close();
            }
            );
            Messenger.Default.Register<string>(this, "Cancel", x =>
            {
                model = null;
                Close();
            }
            );
        }

       
    }
}
