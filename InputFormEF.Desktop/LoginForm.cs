using InputFormEF.BAL;
using InputFormEF.BAL.Dto;
using InputFormEF.BAL.Enums;
using InputFormEF.BAL.Interfaces;
using InputFormEF.DAL;
using InputFormEF.Desktop;
using InputFormEF.Desktop.Utilities;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly ILoginService _loginService;
        //  private readonly IServiceProvider _serviceProvider;

        public LoginForm(ILoginService loginService)
        {
            //  _serviceProvider = serviceProvider;
            _loginService = loginService;
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

            var request = new LoginRequestDto
            {
                UserName = userName,
                Password = password
            };
            var result = await _loginService.LoginAsync(request);
            if (result.Status == Status.Success)

            {
                StudentForm studentForm = Program.ServiceProvider.GetService<StudentForm>();
                studentForm.SetUserName(userName);
                studentForm.Show();
                Hide();
            }
            else
            {
                DialogBox.FailureAlert(result);
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