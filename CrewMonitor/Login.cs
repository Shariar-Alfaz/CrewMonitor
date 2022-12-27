using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrewMonitor.Services;

namespace CrewMonitor
{
    public partial class Login : Form
    {
        private readonly LoginService loginService;
        public Login()
        {
            InitializeComponent();
            this.loginService = new LoginService();
        }


        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var s = await this.loginService.Login(txtUserName.Text, txtPassword.Text);
            if (s == null)
            {
                MessageBox.Show("Wrong");
                return;
            }
            this.loginService.SaveMe(s);
            new Form1().Show();
            this.Hide();
        }

        private void onLoad(object sender, EventArgs e)
        {

        }
    }
}
