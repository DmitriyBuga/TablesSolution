using IPluginsConnect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ConnectTable.Model
{
    class ListTablesItem
    {
        public string tableName { get; set; }
        public string serverName { get; set; }
        public List<string> fields { get; set; }
        public IPlugins SelectedPlugin { get; set; }
        public string connectionString { get; set; }
        public string database { get; set; }
        public DataGrid dataGrid { get; set; }
    }
}
