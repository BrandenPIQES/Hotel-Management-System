using System;
using System.Windows.Forms;
using System.Drawing;
using Phumpla_Kamnandi.Application;

namespace Phumla_Kamnandi
{
    public partial class signInForm : Form
    {
        #region Variable Declaration
        EmployeeController empController;
        Employee employee;
        #endregion
        public signInForm()
        {
            InitializeComponent();
            InitializePlaceholders();
          

            empController = new EmployeeController();
            this.employee = new Employee();
        }
        // Method to initialize placeholder text for both textboxes
        private void InitializePlaceholders()
        {
            // Employee ID TextBox - Placeholder
            SetPlaceholder(employeeIdTextBox, "Enter your Employee ID");

            // Password TextBox - Placeholder
            SetPlaceholder(passwordTextBox, "Enter your Password");
        }

        private void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.LightGray;
        }

        private void ClearPlaceholder(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == placeholderText)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
                if (textBox == passwordTextBox)
                {
                    textBox.UseSystemPasswordChar = true;  // Hide password input
                }
            }
        }

        private void RestorePlaceholder(TextBox textBox, string placeholderText)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.UseSystemPasswordChar = false;  // Disable password hiding
                SetPlaceholder(textBox, placeholderText);
            }
        }

        private void employeeIdTextBox_Enter(object sender, EventArgs e)
        {
            ClearPlaceholder(employeeIdTextBox, "Enter your Employee ID");
        }

        private void employeeIdTextBox_Leave(object sender, EventArgs e)
        {
            RestorePlaceholder(employeeIdTextBox, "Enter your Employee ID");
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            ClearPlaceholder(passwordTextBox, "Enter your Password");
        }

        private void passwordTextBox_Leave(object sender, EventArgs e)
        {
            RestorePlaceholder(passwordTextBox, "Enter your Password");
        }

        private bool VerifyLogin(string employeeID, string password) {

            Employee employee = empController.Find(employeeID);

            if (employee != null) {
                return employee.PasswordHash == password;
            }

            return false;
        }


        public event EventHandler LoginSuccessful;
        private void SignInButton_Click(object sender, EventArgs e)
        {
            string employeeID = employeeIdTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (VerifyLogin(employeeID, password))
            {
                employee = empController.Find(employeeID);
                SessionManager.CurrentEmployee = employee;


                HomePage homePage = new HomePage();
                homePage.MdiParent = this.MdiParent;
                homePage.WindowState = FormWindowState.Normal;
                homePage.Show();

                LoginSuccessful?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Credentials, try again.");
                employeeIdTextBox.Focus();
            }
        }

        private void signInForm_Load(object sender, EventArgs e)
        {

        }

        private void employeeIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
