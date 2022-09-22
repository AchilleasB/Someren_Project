using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenLogic;
using SomerenModel;

namespace SomerenUI
{
    public partial class LoginForm : Form
    {
        User user;
        LoginService loginService;

        public LoginForm()
        {
            InitializeComponent();

            user = new User();
            loginService = new LoginService();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != string.Empty)
                {
                    // retrieve the registered user by the username provided
                    string username = txtUsername.Text;
                    user = loginService.GetRegisteredUser(username);

                    if (user == null)
                    {
                        MessageBox.Show("Incorrect username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUsername.Text = "";
                    }
                    else
                    {
                        user.Username = username;

                        if (CheckPassword())
                        {
                            // display SomereUI
                            SomerenUI somerenUI = new SomerenUI();
                            somerenUI.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter your username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {

                throw new Exception("Operation did not work:" + ex.Message);
            }
            
        }

        //Encrypts the password from the login and checks it with the one in the database
        private bool CheckPassword()
        {
            try
            {
                return user.Digest.ToString() == EncryptPassword(txtPassword.Text, user.Salt).Digest;
            }
            catch (Exception ex)
            {
                throw new Exception("Operation did not work:" + ex.Message);

            }

        }


        private void btnRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registration = new RegistrationForm();
            registration.ShowDialog();
        }
         
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPasswordWindow forgotPassword = new ForgotPasswordWindow();
            forgotPassword.ShowDialog();
        }

        private HashWithSaltResult EncryptPassword(string password, string salt)
        {
            PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
            HashWithSaltResult hashResultSha256 = pwHasher.Hash(password, SHA256.Create(), salt);

            return hashResultSha256;
        }
    }
}
