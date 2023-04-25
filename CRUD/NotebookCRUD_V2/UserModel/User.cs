using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;

namespace NotebookCRUD_V2.UserModel
{
    public class User : IUser
    {
        DataBaseService.IDBConnector connector = new DataBaseService.DBConnector();
        private string salt = BCrypt.Net.BCrypt.GenerateSalt(6);
        private int id;
        private string name;
        private string surname;
        private string username;
        private string password;

        public User(string username, string password, string name,string surname)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.surname = surname;
        }

        public User(string username)
        {
            this.username = username;
            connector.connectionOpen();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE `user_name` = @username;", connector.getConnection());
            cmd.Parameters.AddWithValue("username", username);
            MySqlDataReader reader;
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.id = reader.GetInt32(0);
                    this.password = reader.GetString(3);
                    this.name = reader.GetString(2);
                    this.surname = reader.GetString(4);
                }
                connector.connectionClose();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool Login(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, this.password);
        }

        public void Register()
        {
            string pass = BCrypt.Net.BCrypt.HashPassword(this.password);
            MySqlCommand command = new MySqlCommand("INSERT INTO `users`(`user_name`, `password`, `first_name`, `surname`) VALUES (@usrName, @pass, @name, @surname)", connector.getConnection());
            command.Parameters.Add("@usrName", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            connector.connectionOpen();
            if (this.checkUsername())
            {
                MessageBox.Show("Username is taken", "Error", MessageBoxButtons.OK);
            }
            else
            {
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Error with database", "Error", MessageBoxButtons.OK);
                }
            }
            connector.connectionClose();
        }

        private bool checkUsername()
        {

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `user_name` = @usn", connector.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public int getID()
        {
            return id;
        }
    }
}
