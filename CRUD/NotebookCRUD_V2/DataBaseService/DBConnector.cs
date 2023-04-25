using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace NotebookCRUD_V2.DataBaseService
{
    internal class DBConnector : IDBConnector
    {
        MySqlConnection connection = new MySqlConnection("server = localhost; port=3306;username=root;password=;database=notebook_v2");
        
        public void connectionClose()
        {
            connection.Close();
        }

        public void connectionOpen()
        {
           connection.Open();
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public MySqlDataReader ExecuteReader(string sql)
        {
            try
            {
                MySqlDataReader reader;
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                reader = cmd.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}
