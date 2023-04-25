using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotebookCRUD_V2.NoteModel;
using NotebookCRUD_V2.UserModel;
using NotebookCRUD_V2.DataBaseService;

namespace NotebookCRUD_V2.View
{
    public partial class notebookForm : Form
    {
        IDBConnector con = new DBConnector();
        private INote selectedNote = null;
        private IUser user = null;

        public notebookForm(IUser user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void loadDataButton_Click(object sender, EventArgs e)
        {
            con.connectionOpen();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM notes WHERE `id_user` = @user_id;", con.getConnection());
            cmd.Parameters.AddWithValue("user_id", user.getID());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet set = new DataSet();
            adapter.Fill(set);
            this.dataGridView1.DataSource = set.Tables[0];
            con.connectionClose();

        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            if (selectedNote == null)
            {
                MessageBox.Show("Note is not selected please select one", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Form Reader = new Reader(selectedNote);
                Reader.Show();
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Form Editor = new Editor(user);
            Editor.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (selectedNote == null)
            {
                MessageBox.Show("Note is not selected please select one", "Error", MessageBoxButtons.OK);
            }
            else
            { 
                Form Editor = new Editor(selectedNote, user);
                Editor.Show();
            }   
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            con.connectionOpen();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `notes` WHERE `notes_id` = @id;",con.getConnection());
            cmd.Parameters.AddWithValue("id", selectedNote.getID());
            cmd.ExecuteNonQuery();
            con.connectionClose();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0)
            {
                selectedNote = null;
                return;
            } 
            else
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[index];
                if (dataGridView1.Rows.Count >0)
                {
                    Note note = new Note(int.Parse(selectedRow.Cells[0].Value.ToString()), selectedRow.Cells[2].Value.ToString(), selectedRow.Cells[3].Value.ToString());
                    selectedNote = note;
                }
                else
                {
                    selectedNote = null;
                }
            } 
        }

        private void notebookForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
