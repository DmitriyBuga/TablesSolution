using IPluginsConnect;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TableConnect.Model
{
    public class ConnectionFormModel : Window
    {
        public ConnectionFormModel(List<IPlugins> plugins)
        {
            pluginsList = plugins;
            pluginNames = new ObservableCollection<string>();
            foreach (IPlugins plugin in pluginsList)
                pluginNames.Add(plugin.DisplayPluginName);
        }
        public List<string> listFields { get; set; }
        public List<string> listDatabases { get; set;}
        public List<IPlugins> pluginsList { get; set; }
        ObservableCollection<string> pluginNames { get; set; }
        public IPlugins Plugin { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool useWindowsAuth { get; set; }
        public string serverName { get; set; }
        public string tableName { get; set; }
        public string databaseName { get; set; }
    }
}
