using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyApp;
namespace MyApp
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) 
                || string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MessageBox.Show("UserName and password must not be blank");
                return;
            }
            
            if (Database.Instance.login(txtUserName.Text, txtPassword.Text) == true)
            {

            }
            else
            {
                MessageBox.Show("Cannot login to System");
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            
        }
    }
}
