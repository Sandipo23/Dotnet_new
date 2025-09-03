using InputForm.BAL;
using InputForm.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        private readonly LoginService _loginService;

        public LoginForm()
        {
            _loginService = new LoginService();
            InitializeComponent();
            InitializeFormComponents();
        }

        private void InitializeFormComponents()
        {
            txtUserName.TabIndex = 0;
            txtPassword.TabIndex = 1;
            btnLogin.TabIndex = 2;
            btnCancel.TabIndex = 3;
            txtPassword.PasswordChar = '*';
            this.AcceptButton = btnLogin;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password is required.", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetControls();
                return;
            }
            if (await _loginService.LoginAsync(userName, password))    // this is the code that returns 1/true if the username and password matches
            {
                StudentForm studentForm = new StudentForm();
                studentForm.SetUserName(userName);
                studentForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Invalid credentials.", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResetControls();
        }

        private void ResetControls()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }
    }
}