using IPluginsConnect;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlConnectPlugIn
{
    public class SqlConnectPlugIn : IPlugins
    {
        private string _PluginName = "PluginMySqlConnect";
        private string _DisplayPluginName = "Плагин для MySQL";
        private string _PluginDescription = "Описание";
        private string _Author = "Dev";
        private int _Version = 100;
        private IPluginHost _Host;
        private MySqlConnection sqlConnection { get; set; }
        public List<string> listDatabases { get; set; }
        public List<string> listTables { get; set; }
        public List<string> listFields { get; set; }
        public DataTable table { get; set; }

        public void CloseConnection()
        {
            sqlConnection.Close();
            //if (connect != null)
            //  connect.Close();
        }

        public bool SetFilter(string tableName, string query)
        {
            sqlConnection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, sqlConnection);
            table = new DataTable(tableName);
            adapter.Fill(table);
            sqlConnection.Close();
            return true;
        }
        public bool OpenTable(string strConnect, string tableName)
        {
            //SqlConnection con = ;
            sqlConnection = new MySqlConnection(strConnect.ToString());
            try
            {
                //sqlConnection.Open();
                string query = "select * from " + tableName;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, sqlConnection);
                table = new DataTable(tableName);
                adapter.Fill(table);
                //sqlConnection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool ConnectToDataBase(string strConnect)
        {
            sqlConnection = new MySqlConnection(strConnect.ToString());
            try
            {
                sqlConnection.Open();
                listTables = new List<string>();
                using (DataTable dt = sqlConnection.GetSchema("Tables"))
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        listTables.Capacity = dt.Rows.Count;
                        foreach (DataRow row in dt.Rows)
                            listTables.Add(row["table_name"].ToString());
                    }
                }
                sqlConnection.Close();
                //string query = "select * from sys.tables where type_desc = 'USER_TABLE'";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }
        public bool TestConnection(string strConnect)
        {

            sqlConnection = new MySqlConnection(strConnect.ToString());
            try
            {
                //sqlConnection.ConnectionString = strConnect;
                //DataTable schemaTable = sqlConnection.GetSchema("Databases");
                sqlConnection.Open();
                listDatabases = new List<string>();
                using (DataTable dt = sqlConnection.GetSchema("Databases"))
                {
                    //List<string> list = new List<string>();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        listDatabases.Capacity = dt.Rows.Count;
                        foreach (DataRow row in dt.Rows)
                            listDatabases.Add(row["database_name"].ToString());
                    }
                    //return list;
                }
                sqlConnection.Close();
                /*
                string query = "SELECT name FROM sys.databases WHERE database_id > 4";
                DataTable table = new DataTable("Dbs");
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                adapter.Fill(table);
                sqlConnection.Close();
                for (int i = 0; i < table.Rows.Count; i++)
                    listDatabases.Add(table.Rows[i][0].ToString());
                //foreach(DataRowCollection row in table.Rows)
                    //listDatabases.Add(row[0].ToString());
                */
                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }

        }
        public IPluginHost Host
        {
            get { return this._Host; }
            set
            {
                this._Host = value;
                this._Host.Register(this);
            }
        }

        public string PluginName
        {
            get { return this._PluginName; }
        }

        public string DisplayPluginName
        {
            get { return this._DisplayPluginName; }
        }

        public string PluginDescription
        {
            get { return this._PluginDescription; }
        }

        public string Author
        {
            get { return this._Author; }
        }

        public int Version
        {
            get { return this._Version; }
        }
    }
}
