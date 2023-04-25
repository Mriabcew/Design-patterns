using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotebookCRUD_V2.NoteModel;
using NotebookCRUD_V2.DataBaseService;
using NotebookCRUD_V2.UserModel;

namespace NotebookCRUD_V2.View
{
    public partial class Editor : Form
    {
        IUser user = null;
        INote note = null;
        public Editor(INote note, IUser user)
        {
            InitializeComponent();
            this.note = note;
            this.txtBody.Text = note.getBody();
            this.txtTitle.Text = note.getTitle();
            this.user = user;

        }
        public Editor(IUser user)
        {
            InitializeComponent();
            this.user = user;
        }

        public Editor()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            IDBConnector connector = new DBConnector();
            MySqlCommand command = new MySqlCommand("INSERT INTO `notes`(`note_title`, `note_body`, `id_user`) VALUES (@note_title, @note_body, @user_id)", connector.getConnection());
            command.Parameters.Add("@note_title", MySqlDbType.VarChar).Value = txtTitle.Text;
            command.Parameters.Add("@note_body", MySqlDbType.VarChar).Value = txtBody.Text;
            command.Parameters.Add("@user_id", MySqlDbType.Int32).Value = user.getID();
            connector.connectionOpen();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Your Note Has Been Saved", "Note Save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error with database", "Error", MessageBoxButtons.OK);
            }
            connector.connectionClose();
        }

        private void update_Click(object sender, EventArgs e)
        {
            IDBConnector connector = new DBConnector();
            MySqlCommand command = new MySqlCommand("UPDATE notes SET note_title = @note_title, note_body = @note_body WHERE notes_id = @notes_id;", connector.getConnection());
            command.Parameters.Add("@note_title", MySqlDbType.VarChar).Value = txtTitle.Text;
            command.Parameters.Add("@note_body", MySqlDbType.Text).Value = txtBody.Text;
            command.Parameters.Add("@notes_id", MySqlDbType.Int32).Value = note.getID();
            connector.connectionOpen();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Your Note Has Been Updated", "Note Save", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error with database", "Error", MessageBoxButtons.OK);
            }
            connector.connectionClose();
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
