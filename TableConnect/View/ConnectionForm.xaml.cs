using IPluginsConnect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
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
using TableConnect.Model;

namespace TableConnect.View
{
    /// <summary>
    /// Логика взаимодействия для ConnectionForm.xaml
    /// </summary>
    public partial class ConnectionForm : Window
    {
        public ConnectionFormModel formModel;
        private List<IPlugins> _plugins;

        private void LoadPlugins(string path)
        {
            string[] pluginFiles = Directory.GetFiles(path, "*.dll");
            this._plugins = new List<IPlugins>();

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
                        this._plugins.Add((IPlugins)Activator.CreateInstance(objType));
                        this._plugins[this._plugins.Count - 1].Host = (IPluginHost)this;
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
        public ConnectionForm()
        {
            InitializeComponent();
            //formModel = new ConnectionFormModel();
            /*
            LoadPlugins(AppDomain.CurrentDomain.BaseDirectory);
            formModel = new ConnectionFormModel(_plugins);
            foreach (IPlugins name in formModel.pluginsList)
              cmbSelectPlugin.Items.Add(name.PluginName);
            */
        }

        private void btnOpenTable_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnTestConnect_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = this.cmbSelectPlugin.SelectedIndex;
            SqlConnectionStringBuilder connectionString = new SqlConnectionStringBuilder();
            //connectionString.AttachDBFilename = "Master";
            connectionString.DataSource = @".\SQLEXPRESS";//txtDataSource.Text;
            connectionString.UserID = "sa";//txtUserID.Text;
            connectionString.Password = "123qwe";//txtPassword.Text;
            connectionString.ConnectTimeout = 30;
            //connectionString.InitialCatalog = "Master";                        
            if (this._plugins[selectedIndex].TestConnection(connectionString.ConnectionString))
            {
                formModel.listFields = this._plugins[selectedIndex].listFields;
                formModel.listDatabases = this._plugins[selectedIndex].listDatabases;
            }
        }
    }
}
