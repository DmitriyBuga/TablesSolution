using ConnectTable.Helpers;
using ConnectTable.Model;
using ConnectTable.View;
using GalaSoft.MvvmLight.Messaging;
using IPluginsConnect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConnectTable.ViewModel
{
    class ViewModelTables : ViewModelBase
    {
        public ObservableCollection<ListTablesItem> listTables { get; set; }
        public ObservableCollection<TabItem> TabItems { get; set; }
        public RelayCommand OpenTableUserCommand { get; set; }
        public RelayCommand SetFilterUserCommand { get; set; }
        public RelayCommand ClearFilterUserCommand { get; set; }
        public RelayCommand CloseUserCommand { get; set; }
        public RelayCommand Export2XLSUserCommand { get; set; }
        public RelayCommand Export2PDFUserCommand { get; set; }
        public RelayCommand Export2CSVUserCommand { get; set; }
        public RelayCommand CloseTableUserCommand { get; set; }
        
        public IPlugins SelectedPlugin { get; set; }
        public List<ConnectTableParameters> listPars { get; set; }
        //public SqlConnection sqlConnection { get; set; }
        
        public ViewModelTables()
        {

            listTables = new ObservableCollection<ListTablesItem>();
            TabItems = new ObservableCollection<TabItem>();
            OpenTableUserCommand = new RelayCommand(OpenTable);
            SetFilterUserCommand = new RelayCommand(SetFilter);
            ClearFilterUserCommand = new RelayCommand(ClearFilter);
            CloseUserCommand = new RelayCommand(CloseViewTables);
            Export2PDFUserCommand = new RelayCommand(Export2Pdf);
            Export2CSVUserCommand = new RelayCommand(Export2Csv);
            CloseTableUserCommand = new RelayCommand(CloseTable);
            Export2XLSUserCommand = new RelayCommand(Export2Xls);
            //OpenTables();
        }

        public void OpenTables()
        {
            LoadConnectTableParsFromFile();
            ConnectWindow cwWnd = new ConnectWindow();
            cwWnd.InitModel();
            if (cwWnd.model != null)
            {
                foreach (ConnectTableParameters parameter in listPars)
                {
                    SelectedPlugin = cwWnd.model.listPlugins.FirstOrDefault(x => x.PluginName == parameter.pluginName);
                    if (SelectedPlugin != null)
                    {
                        if (SelectedPlugin.OpenTable(parameter.connectionString, parameter.tableName))
                        {
                            ListTablesItem list = new ListTablesItem
                            {
                                tableName = parameter.tableName,
                                serverName = parameter.dataSource,
                                fields = SelectedPlugin.listFields,
                                SelectedPlugin = SelectedPlugin,
                                database = parameter.database, 
                                //sqlConnection = SelectedPlugin.sqlConnection,
                                connectionString = parameter.connectionString
                            };
                            listTables.Add(list);
                            //sqlConnection = SelectedPlugin.sqlConnection;
                            Messenger.Default.Send<ListTablesItem>(list, "AppendTabItem");
                        }
                    }
                }
            }
            cwWnd.Close();
        }
        public void SaveConnectTablePars2File()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            listPars = new List<ConnectTableParameters>();
            foreach (ListTablesItem table in listTables)
                listPars.Add(new ConnectTableParameters
                {
                    connectionString = table.connectionString,
                    tableName = table.tableName,
                    database = table.database,
                    dataSource = table.serverName,
                    pluginName = table.SelectedPlugin.PluginName
                });
            using (FileStream fs = new FileStream("OpenedTables.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, listPars);
            }
        }
        public void LoadConnectTableParsFromFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            listPars = new List<ConnectTableParameters>();
            using (FileStream fs = new FileStream("OpenedTables.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    listPars = (List<ConnectTableParameters>)formatter.Deserialize(fs);
            }
                
        }
        
        public void CloseTable(object parameters)
        {
            Messenger.Default.Send<string>("", "CloseSelectedTable");
        }
        public void Export2Xls(object parameters)
        {
            Messenger.Default.Send<string>("", "Export2Xls");
        }
        public void Export2Pdf(object parameters)
        {
            Messenger.Default.Send<string>("", "Export2Pdf");
        }
        public void Export2Csv(object parameters)
        {
            Messenger.Default.Send<string>("", "Export2Csv");
        }
        public void CloseViewTables(object parameter)
        {
            SaveConnectTablePars2File();
            Messenger.Default.Send<string>("", "CloseViewTables");
        }
        public void ClearFilter(object parameter)
        {
            Messenger.Default.Send<string>("", "ClearFilter");
        }
        public void SetFilter(object parameter)
        {
            Messenger.Default.Send<string>("", "OpenSetFilterView");
        }

        public void OpenTable(object parameter)
        {
            ConnectWindow cwWnd = new ConnectWindow();
            cwWnd.ShowDialog();
            if (cwWnd.model != null)
            {
                SelectedPlugin = cwWnd.model.SelectedPlugin;

                //                cwWnd.model.CreateConnectionString();
                string connectionString = cwWnd.model.CreateConnectionString();
                if (SelectedPlugin.OpenTable(connectionString, cwWnd.model.SelectedTable))
                {
                    ListTablesItem list = new ListTablesItem
                    {
                        tableName = cwWnd.model.SelectedTable,
                        serverName = cwWnd.model.connectPars.serverName,
                        fields = SelectedPlugin.listFields,
                        database = cwWnd.model.SelectedDatabase,
                        SelectedPlugin = SelectedPlugin,
                        //sqlConnection = SelectedPlugin.sqlConnection,
                        connectionString = connectionString
                    };
                    listTables.Add(list);
                    //sqlConnection = SelectedPlugin.sqlConnection;
                    Messenger.Default.Send<ListTablesItem>(list, "AppendTabItem");
                }

            }
        }
    }
}
