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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegistrationSubmit_Click(object sender, EventArgs e)
        {
            // make sure all fields are filled before validating further
            if (!String.IsNullOrEmpty(txtBoxRegistrationUsername.Text)
                && !String.IsNullOrEmpty(txtBoxRegistrationPassword.Text)
                && !String.IsNullOrEmpty(txtBoxRegistrationLicenseKey.Text)
                && !String.IsNullOrEmpty(txtBoxRegistrationName.Text)
                && !String.IsNullOrEmpty(txtBoxRegistrationEmail.Text))
            {
                RegistrationService registrationService = new RegistrationService();
                // validate the password after triming the white spaces if any
                if (registrationService.ValidatePassword(txtBoxRegistrationPassword.Text.Trim()))
                {
                    // validate the key
                    if (registrationService.ValidateLicenseKey(txtBoxRegistrationLicenseKey.Text))
                    {
                        // not adding role to the model object because its been already in the database default to user
                        User user = new User();
                        user.Username = txtBoxRegistrationUsername.Text;
                        user.Name = txtBoxRegistrationName.Text;
                        user.Email = txtBoxRegistrationEmail.Text;
                        user.Role = true;
                        user.SecretQuestion = "";
                        user.SecretAnswer = "";

                        // hash the password and get the salt to store it in DB
                        HashWithSaltResult hashResultSha256 = EncryptPassword(txtBoxRegistrationPassword.Text);
                        user.Salt = hashResultSha256.Salt;
                        user.Digest = hashResultSha256.Digest;

                        try
                        {
                            registrationService.AddUser(user);

                            txtBoxRegistrationUsername.Text = "";
                            txtBoxRegistrationPassword.Text = "";
                            txtBoxRegistrationLicenseKey.Text = "";
                            txtBoxRegistrationName.Text = "";
                            txtBoxRegistrationEmail.Text = "";

                            MessageBox.Show("User has been added successfully.", "Registration");

                            // redirect the user to the login form after successful registration
                            new LoginForm().Show();
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred!\n{ex.Message}", "SQL Server Error");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The provided license key is invalid!", "Invalid License Key");
                    }
                }
                else
                {
                    MessageBox.Show("Password must be 8 characters length," +
                        "and containes at least:\n" +
                        "One lowercase letter\n" +
                        "One uppercase letter\n" +
                        "One number\n" +
                        "One special character",
                        "Invalid password");
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields!", "Incomplete data");
            }
        }

        private void btnRegistrationCancel_Click(object sender, EventArgs e)
        {
            // go to login form
            new LoginForm().Show();
            this.Close();
        }

        //Encrypts the password
        private HashWithSaltResult EncryptPassword(string password)
        {
            PasswordWithSaltHasher pwHasher = new PasswordWithSaltHasher();
            HashWithSaltResult hashResultSha256 = pwHasher.HashWithSalt(password, 64, SHA256.Create());

            return hashResultSha256;
        }
    }
}
