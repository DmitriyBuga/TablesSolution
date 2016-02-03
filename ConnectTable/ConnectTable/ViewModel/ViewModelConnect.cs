using ConnectTable.Helpers;
using ConnectTable.Model;
using GalaSoft.MvvmLight.Messaging;
using IPluginsConnect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ConnectTable.ViewModel
{
    public class ViewModelConnect : ViewModelBase

    {
        public ConnectPars connectPars { get; set; }
        public ObservableCollection<string> listTables { get; set; }
        public ObservableCollection<string> listDatabases { get; set; }
        public ObservableCollection<IPlugins> listPlugins { get; set; }
        public RelayCommand ConnectUserCommand { get; set; }
        public RelayCommand OpenTableUserCommand { get; set; }
        public RelayCommand CloseConnectWindowUserCommand { get; set; }
        private bool _IsEnableConnectButton()
        {
            return (connectPars.boolUsingWindowsAuth
                || connectPars.userName.Length > 0 && connectPars.userName.Length > 0)
                && connectPars.serverName.Length > 0;
        }
        string _SelectedTable;
        public string SelectedTable
        {
            get { return _SelectedTable; }
            set
            {
                if (value != _SelectedTable)
                {
                    _SelectedTable = value;
                    Messenger.Default.Send<bool>(_SelectedTable != null, "EnableOpenButton");
                }
            }
        }
        string _SelectedDatabase;
        public string SelectedDatabase
        {
            get { return _SelectedDatabase; }
            set
            {
                if (_SelectedDatabase != value)
                {
                    _SelectedDatabase = value;
                    ConnectToDatabase();                        
                    Messenger.Default.Send<bool>(SelectedDatabase != null, "EnableSelectTable");
                }
            }
        }
        IPlugins _SelectedPlugin;
        public IPlugins SelectedPlugin
        {
            get { return _SelectedPlugin; }
            set
            {
                if (_SelectedPlugin != value)
                {
                    _SelectedPlugin = value;
                    RaisePropertyChanged("SelectedPlugin");
                    Messenger.Default.Send<bool>(_IsEnableConnectButton(), "EnableBtnConnect");
                    Messenger.Default.Send<bool>(false, "EnableSelectDataBase");
                }
            }
        }
        private void LoadPlugins(string path)
        {
            //path += @"\Plugins\\";
            string[] pluginFiles = Directory.GetFiles(path, "*.dll");
            this.listPlugins = new ObservableCollection<IPlugins>();

            foreach (string pluginPath in pluginFiles)
            {
                Type objType = null;
                try
                {
                    // пытаемся загрузить библиотеку
                    Assembly assembly = Assembly.LoadFrom(pluginPath);
                    if (assembly != null)
                    {
                        objType = assembly.GetType(System.IO.Path.GetFileNameWithoutExtension(pluginPath) + ".SqlConnectPlugIn");
                    }
                }
                catch
                {
                    continue;
                }
                try
                {
                    if (objType != null)
                    {
                        this.listPlugins.Add((IPlugins)Activator.CreateInstance(objType));
                        this.listPlugins[this.listPlugins.Count - 1].Host = (IPluginHost)this;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
        
        
        public ViewModelConnect()
        {
            listTables = new ObservableCollection<string>();
            listDatabases = new ObservableCollection<string>();
            LoadPlugins(AppDomain.CurrentDomain.BaseDirectory + "plugins");
            connectPars = new ConnectPars
            {
                userName = "sa",
                password = "123qwe",
                serverName = @".\SQLEXPRESS"
            };
            ConnectUserCommand = new RelayCommand(ConnectToServer);
            OpenTableUserCommand = new RelayCommand(OpenTable);
            CloseConnectWindowUserCommand = new RelayCommand(CloseWindow);
        }
        void CloseWindow(object parameter)
        {
            Messenger.Default.Send<string>("", "Cancel");
        }
        void ConnectToDatabase()
        {
            listTables.Clear();
            if (SelectedPlugin.ConnectToDataBase(CreateConnectionString()))
                foreach (string db in SelectedPlugin.listTables)
                    listTables.Add(db);
        }
        public string CreateConnectionString()
        {
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            connectionString.InitialCatalog = SelectedDatabase == null ? "": SelectedDatabase;
            connectionString.UserID = connectPars.userName;
            connectionString.Password = connectPars.password;
            connectionString.DataSource = connectPars.serverName;
            return connectionString.ConnectionString;
        }
        void OpenTable(object parameter)
        {
            Messenger.Default.Send<ViewModelConnect>(this, "OpenTable");
        }
        void ConnectToServer(object parameter)
        {
            listDatabases.Clear();
            if (SelectedPlugin.TestConnection(CreateConnectionString()))
            {
                foreach (string db in SelectedPlugin.listDatabases)
                    listDatabases.Add(db);
                Messenger.Default.Send<bool>(true, "EnableSelectDataBase");
            }
                
        }
    }
}
