using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookCRUD_V2.DataBaseService
{
    internal interface IDBConnector
    {
        void connectionOpen();
        void connectionClose();
        MySqlConnection getConnection();
        MySqlDataReader ExecuteReader(string query);
    }
}
