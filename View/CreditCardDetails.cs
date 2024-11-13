using Phumpla_Kamnandi.Application;
using Phumpla_Kamnandi.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reservations
{
    public partial class CreditCardDetailsForm : Form
    {
        
        private ReservationController reservationController;
        private TransactionController transactionController;
        private Reservation reservation;
        private string reservationId;
        private string customerId;
        private DateTime checkInTime;
        private DateTime checkOutTime;
        private decimal totalPrice;
        private string Status;
        private string email;
        private string transactionId;
        public CreditCardDetailsForm(string reservationId, string customerId, DateTime checkInTime, DateTime checkOutTime, decimal totalPrice, string Status,string email)
        {
            InitializeComponent();
            InitializePlaceholders();
            reservationController = new ReservationController();
            transactionController = new TransactionController();
            this.email = email;
            this.reservationId = reservationId;
            this.checkInTime = checkInTime;
            this.checkOutTime = checkOutTime;
            this.totalPrice = totalPrice;
            this.Status = Status;
            this.customerId = customerId;
            this.transactionId = Guid.NewGuid().ToString();


            // Attach event handlers for validation
            CreditCardNumberTextBox.KeyPress += CreditCardNumberTextBox_KeyPress;
            CreditCardNumberTextBox.TextChanged += CreditCardNumberTextBox_TextChanged;
            CreditCardNumberTextBox.Enter += CreditCardNumberTextBox_Enter; 
            CreditCardNumberTextBox.Leave += CreditCardNumberTextBox_Leave;  

            expTextBox.KeyPress += ExpTextBox_KeyPress;
            expTextBox.Leave += ExpTextBox_Leave;

            CVVTextBox.KeyPress += CVVTextBox_KeyPress;
        }
        public CreditCardDetailsForm(Reservation res,ReservationController reservationController,String email) 
        {
            InitializeComponent();
            InitializePlaceholders();
            this.reservationController = reservationController;
            transactionController = new TransactionController();
            this.email = email;
            this.reservation = res;
            this.reservationId = res.ReservationID;
            this.checkInTime = res.CheckInDate;
            this.checkOutTime = res.CheckOutDate;
            this.totalPrice = res.TotalAmount;
            this.Status = res.Status;
            this.customerId = res.CustomerID;
            this.transactionId = Guid.NewGuid().ToString();


            // Attach event handlers for validation
            CreditCardNumberTextBox.KeyPress += CreditCardNumberTextBox_KeyPress;
            CreditCardNumberTextBox.TextChanged += CreditCardNumberTextBox_TextChanged;
            CreditCardNumberTextBox.Enter += CreditCardNumberTextBox_Enter;
            CreditCardNumberTextBox.Leave += CreditCardNumberTextBox_Leave;

            expTextBox.KeyPress += ExpTextBox_KeyPress;
            expTextBox.Leave += ExpTextBox_Leave;

            CVVTextBox.KeyPress += CVVTextBox_KeyPress;
        }  
        // Method to initialize placeholder text for both textboxes
        private void InitializePlaceholders()
        {
            // Credit Card Number TextBox - Placeholder
            CreditCardNumberTextBox.Text = "Enter a credit card number";
            CreditCardNumberTextBox.ForeColor = Color.LightGray;

            // Month TextBox - Placeholder

            expTextBox.Text = "MM/YYYY";
            expTextBox.ForeColor = Color.LightGray;


            // CVV TextBox - Placeholder
            CVVTextBox.Text = "CVV";
            CVVTextBox.ForeColor = Color.LightGray;
        }

        // Event handler to restrict card number input to digits
        private void CreditCardNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Prevent non-numeric input
            }
        }

      


        // Event handler for restricting MM/YYYY format
        private void ExpTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true; // Allow only digits and '/'
            }
        }


        // Validate the expiry date format and check for upcoming years
        private void ExpTextBox_Leave(object sender, EventArgs e)
        {
            string expiryText = expTextBox.Text.Trim();

            // Check MM/YYYY format
            if (!System.Text.RegularExpressions.Regex.IsMatch(expiryText, @"^(0[1-9]|1[0-2])\/[0-9]{4}$"))
            {
                MessageBox.Show("Invalid expiry date format. Please enter MM/YYYY.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expTextBox.Focus();
                return;
            }

            // Extract month and year
            int month = int.Parse(expiryText.Substring(0, 2));
            int year = int.Parse(expiryText.Substring(3, 4));

            // Ensure year is upcoming or current
            int currentYear = DateTime.Now.Year;

            if (year < currentYear || (year == currentYear && month < DateTime.Now.Month))
            {
                MessageBox.Show("Expiry date cannot be in the past. Please enter a valid expiry date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                expTextBox.Focus();
            }
        }


        // Restrict CVV input to numbers only
        private void CVVTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Allow only digits and control characters
            }
        }


        private void CreditCardNumberTextBox_Enter(object sender, EventArgs e)
        {
            //if (CreditCardNumberTextBox.Text == "Enter a credit card number")
            {
                CreditCardNumberTextBox.Text = "";  // Clear placeholder 
                CreditCardNumberTextBox.ForeColor = Color.Black;  // Set normal text color
            }

        }

        private void CreditCardNumberTextBox_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(CreditCardNumberTextBox.Text))
            {
                CreditCardNumberTextBox.Text = "Enter a credit card number";  // Restore placeholder for > 4 years
                CreditCardNumberTextBox.ForeColor = Color.LightGray;  // Set placeholder color
            }
        }

        private void MonthTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(expTextBox.Text))
            {
                expTextBox.Text = "MM/YYYY";  // Restore placeholder 
                expTextBox.ForeColor = Color.LightGray;  // Set placeholder color
            }
        }

        private void MonthTextBox_Enter(object sender, EventArgs e)
        {
            if (expTextBox.Text == "MM/YYYY")
            {
                expTextBox.Text = "";  // Clear placeholder 
                expTextBox.ForeColor = Color.Black;  // Set normal text color
            }
        }

        private void YearTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(expTextBox.Text))
            {
                expTextBox.Text = "Year";  // Restore placeholder 
                expTextBox.ForeColor = Color.LightGray;  // Set placeholder color
            }

        }

        private void YearTextBox_Enter(object sender, EventArgs e)
        {
            if (expTextBox.Text == "Year")
            {
                expTextBox.Text = "";  // Clear placeholder 
                expTextBox.ForeColor = Color.Black;  // Set normal text color
            }
        }

        private void CVVTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CVVTextBox.Text))
            {
                CVVTextBox.Text = "CVV";  // Restore placeholder 
                CVVTextBox.ForeColor = Color.LightGray;  // Set placeholder color
            }
        }

        private void CVVTextBox_Enter(object sender, EventArgs e)
        {
            if (CVVTextBox.Text == "CVV")
            {
                CVVTextBox.Text = "";  // Clear placeholder 
                CVVTextBox.ForeColor = Color.Black;  // Set normal text color
            }
        }

        private void recordTransaction() {
            bool transresult = transactionController.CreateTransaction(transactionId, reservationId, customerId, totalPrice, DateTime.Now);
        }

        private void paybutton_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            MessageBox.Show("Sending confirmation...");

            recordTransaction();
           
            bool result = reservationController.ConfirmReservation(reservation);
               

            if (result)
            {
                BookingConfirmed bookingConfirmed = new BookingConfirmed(reservationId, checkInTime, checkOutTime, totalPrice, reservationController.Find(reservationId).Status,email);
                bookingConfirmed.MdiParent = this.MdiParent;
                bookingConfirmed.WindowState = FormWindowState.Normal;
                bookingConfirmed.Show();
            }
        }

        private void CreditCardDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CreditCardNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (CreditCardNumberTextBox.Text.Length > 16)
            {
                CreditCardNumberTextBox.Text = CreditCardNumberTextBox.Text.Substring(0, 16);
                CreditCardNumberTextBox.SelectionStart = CreditCardNumberTextBox.Text.Length;
            }
        }
    }
}
