using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectTable.Model
{
    [Serializable()]
    class ConnectTableParameters
    {
        public string connectionString { get; set; }
        public string dataSource { get; set; }
        public string tableName { get; set; }
        public string pluginName { get; set; }
        public string database { get; set; }
    }
}
