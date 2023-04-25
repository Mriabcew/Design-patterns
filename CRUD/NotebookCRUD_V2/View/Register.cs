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
    public partial class Register : Form
    {
        Form login = null;
        public Register(Form login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text == "" || txtPassword.Text == "" || txtName.Text == "" ||txtSurname.Text =="")
            {
                MessageBox.Show("Fields are empty", "Error", MessageBoxButtons.OK);
            }
            else if (txtPassword.Text != txtPassRepeat.Text)
            {
                MessageBox.Show("Passwords are different", "Error", MessageBoxButtons.OK);
            }
            else
            {
                IUser user = new User(txtUsername.Text, txtPassword.Text, txtName.Text, txtSurname.Text);
                user.Register();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            login.Show();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
