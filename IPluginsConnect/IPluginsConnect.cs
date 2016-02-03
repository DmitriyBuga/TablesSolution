using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPluginsConnect
{
    
    public interface IPlugins
    {
        string PluginName { get; }
        string DisplayPluginName { get; }
        string PluginDescription { get; }
        string Author { get; } // имя автора
        int Version { get; } // версия
        IPluginHost Host { get; set; } // ссылка на главную форму
        List<string> listDatabases { get; set; }
        List<string> listTables { get; set; }
        List<string> listFields { get; set; }
        DataTable table { get; set; }
        void CloseConnection();
        bool TestConnection(string strConnect);
        bool ConnectToDataBase(string strConnect);
        bool SetFilter(string tableName, string query);
        bool OpenTable(string strConnect, string tableName);
    }
    public interface IPluginHost
    {
        bool Register(IPlugins plug);
    }
}
