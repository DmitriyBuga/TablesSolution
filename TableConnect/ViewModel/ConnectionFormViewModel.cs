using IPluginsConnect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TableConnect.Model;

namespace TableConnect.ViewModel
{
    class ConnectionFormViewModel : ViewModelBase
    {
        public List<string> listFields { get; set; }
        public List<string> listDatabases { get; set; }
        public ObservableCollection<IPlugins> listPlugins;
        object _SelectedPlugin;
        public object SelectedPlugin
        {
            get { return _SelectedPlugin; }
            set
            {
                if (_SelectedPlugin != value)
                {
                    _SelectedPlugin = value;
                    RaisePropertyChanged("SelectedPlugin");
                        
                }
            }
        }
        private void LoadPlugins(string path)
        {
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
        public ConnectionFormViewModel()
        {
            LoadPlugins(AppDomain.CurrentDomain.BaseDirectory);
            ObservableCollection<string> names = new ObservableCollection<string>();
            foreach (IPlugins plugin in listPlugins)
                names.Add(plugin.DisplayPluginName);
            /*
            connectionModel = new ConnectionFormModel
            {
                plugins = plugins,
                pluginsList = plugins,
                userName = "sa",
                password = "123qwe",
                serverName = "",//".\SQLEXPRESS",
                tableName = "",
                databaseName = "homeAcc"
            };
            */
        }
    }
}
