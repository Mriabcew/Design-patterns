using NotebookCRUD_V2.UserModel;
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
    public partial class Login : Form
    {
        Form registerForm = null;
        Form notebookForm = null;
        public Login()
        {
            InitializeComponent();
            registerForm = new Register(this);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerForm.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            IUser user = new User(textBox1.Text);
            if(user.Login(textBox2.Text))
            {
                this.Hide();
                notebookForm = new notebookForm(user);
                notebookForm.Show();
            }
            else
            {
                MessageBox.Show("Bad password", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
