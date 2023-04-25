using NotebookCRUD_V2.NoteModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotebookCRUD_V2.View
{
    public partial class Reader : Form
    {
        public Reader(INote note)
        {
            InitializeComponent();
            Init(note);
        }

        private void Init(INote note)
        {
            try
            {
                this.txtBody.Text = note.getBody();
                this.txtTitle.Text = note.getTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Note not selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
