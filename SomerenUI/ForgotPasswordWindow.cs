using System;
using SomerenLogic;
using SomerenModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SomerenUI
{
    public partial class ForgotPasswordWindow : Form
    {
        User user;

        public ForgotPasswordWindow()
        {
            InitializeComponent();

            textBox1.Enabled = false;
            button2.Enabled = false;

            textBox3.Enabled = false;
            button3.Enabled = false;

            textBox4.Enabled = false;
            textBox5.Enabled = false;
            button4.Enabled = false;

            user = new User();

        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;

            ForgotPasswordService forgotPassword = new ForgotPasswordService();
            string secretQuestion = forgotPassword.GetSecretQuestion(username);

            if (secretQuestion == "")
            {
                MessageBox.Show("Invalid username! Please try again.");
            }
            else 
            {
                label1.Text = secretQuestion;

                textBox1.Enabled = true;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string answer = textBox1.Text;
            string username = textBox2.Text;

            ForgotPasswordService forgotPassword = new ForgotPasswordService();
            string secretAnswer = forgotPassword.GetSecretAnswer(username);

            if (answer == secretAnswer) 
            {
                MessageBox.Show("Correct anwser! You may now change your password and your secret question.");
                textBox3.Enabled = true;
                button3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                MessageBox.Show("Incorrect anwser! Please try again.");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ForgotPasswordService forgotPassword = new ForgotPasswordService();

            string password = textBox3.Text;
            string username = textBox2.Text;
            user.Username = textBox2.Text;

            string[] symbols = { "!", "@", "#", "$", "%", "*" };

            bool isValidPassword = false;

            RegistrationService registrationService = new RegistrationService();

            if (registrationService.ValidatePassword(password))
            {
                isValidPassword = true;
            }

            if (isValidPassword)
            {
                
                // hash the password and get the salt to store it in DB
                HashWithSaltResult hashResultSha256 = EncryptPassword(textBox3.Text);
                user.Salt = hashResultSha256.Salt;
                user.Digest = hashResultSha256.Digest;

                forgotPassword.ChangePassword(user);

                MessageBox.Show("The password was changed successfully!", "Password Changed Successfully");

             }
            else 
            {
                MessageBox.Show("Sorry, the password you enetered isn't strong enough." +
                    "\n\n A passoword must meet the following requirements:\n" + 
                    "\n Minimum length of 8 characters " + 
                    "\n Minimum of 1 lowercase letter" + 
                    "\n Minimum of 1 uppercase letter" + 
                    "\n Minimum of 1 number"+
                    "\n Minimum of 1 special chracter (e.g. !,@,#,$,*)", "Password Not Strong Enough!");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string secretQuestion = textBox4.Text;
            string secretAnswer = textBox5.Text;
            string username = textBox2.Text;

            ForgotPasswordService forgotPassword = new ForgotPasswordService();
            forgotPassword.ChangeSecretQuestion(username, secretQuestion, secretAnswer);

            MessageBox.Show("Secret question changed successfully!", "Secret Question Changed");
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
