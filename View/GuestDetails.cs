using Phumpla_Kamnandi.Application;
using Phumpla_Kamnandi.Data;
using Reservations;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumpla_Kamnandi.View
{
    public partial class GuestDetails : Form
    {
        private decimal totalPrice;
        private ReservationController reservationController;
        private CustomerController customerController;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private string numberOfPeople;

        public GuestDetails(decimal totalPrice, DateTime checkInDate, DateTime checkOutDate, string numberOfPeople)
        {
            InitializeComponent();
            this.totalPrice = totalPrice;
            this.reservationController = new ReservationController();
            this.customerController = new CustomerController();
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.numberOfPeople = numberOfPeople;

            // Ensure event handlers are properly set
            agentradioButton.CheckedChanged += agentradioButton_CheckedChanged;
            individualButton.CheckedChanged += individualradioButton_CheckedChanged;

            // Set KeyPress events for fields
            firstNameTextBox.KeyPress += NameTextBox_KeyPress;
            lastNameTextBox.KeyPress += NameTextBox_KeyPress;
            mobileTextBox.KeyPress += MobileTextBox_KeyPress;

            // Set KeyPress event for postal code field
            postCodeTextBox.KeyPress += PostCodeTextBox_KeyPress;

            // Set TextChanged events to reset the label colors when user types
            firstNameTextBox.TextChanged += ResetLabelColor;
            lastNameTextBox.TextChanged += ResetLabelColor;
            emailTextBox.TextChanged += ResetLabelColor;
            mobileTextBox.TextChanged += ResetLabelColor;
            streetTextBox.TextChanged += ResetLabelColor;
            townTextBox.TextChanged += ResetLabelColor;
            cityTextBox.TextChanged += ResetLabelColor;
            postCodeTextBox.TextChanged += ResetLabelColor;
            postCodeTextBox.TextChanged += ResetLabelColor;

            // Initially, clear all fields
            ClearFormFields();
        }

        private void PostCodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control characters (e.g., backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered into the TextBox
            }

            // Limit the length of the postal code to 4 digits
            if (!char.IsControl(e.KeyChar) && postCodeTextBox.Text.Length >= 4)
            {
                e.Handled = true; // Prevent more than 4 characters from being entered
            }
        }

        // Event handler to restrict input to letters and spaces only in name fields
        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered into the TextBox
            }
        }

        // Event handler to restrict input to digits only in the mobile number field
        private void MobileTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent the character from being entered into the TextBox
            }
        }

        private async void proceedtopayment_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled before proceeding
            if (!ValidateFields())
            {
                await BlinkLabels(); // Blink the labels that are invalid
                MessageBox.Show("Please fill in all required fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop further execution if fields are missing
            }

            // Collect the data from the form fields
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();
            string email = emailTextBox.Text.Trim();
            string mobileNumber = mobileTextBox.Text.Trim();
            string street = streetTextBox.Text.Trim();
            string town = townTextBox.Text.Trim();
            string city = cityTextBox.Text.Trim();
            string postCode = postCodeTextBox.Text.Trim();

            // Create a new customer ID and reservation ID
            string customerId = Guid.NewGuid().ToString().Substring(0, 5);
            string reservationId = Guid.NewGuid().ToString().Substring(0, 5);

            // Your existing logic to handle agent and individual cases

            if (agentradioButton.Checked)
            {
                // Agent: Concatenate agency name and agent ID as FirstName, set LastName as null
                string agencyName = firstNameTextBox.Text.Trim();
                string agentID = lastNameTextBox.Text.Trim();
                firstName = $"{agencyName}";
                lastName = agentID; // Set the last name to null for agent

                // Add the agent to the customer database
                bool customerAdded = customerController.CreateCustomer(customerId, firstName + " - Agency", lastName, email, mobileNumber, street, town, city, postCode);

                if (customerAdded)
                {
                    // Create the reservation for the agent
                    reservationController.CreateReservation(reservationId, customerId, "Standard Room", DateTime.Now, checkInDate, checkOutDate, numberOfPeople, totalPrice);

                    MessageBox.Show("An email has been sent to: " + email + "\n Awaiting Confirmation...");

                    this.Visible = false;
                    AwaitingConfirmation awaitingConfirmation = new AwaitingConfirmation(reservationId, checkInDate, checkOutDate, totalPrice, "Pending", email);
                    awaitingConfirmation.MdiParent = this.MdiParent;
                    awaitingConfirmation.WindowState = FormWindowState.Normal;
                    awaitingConfirmation.Show();
                }
            }
            else if (individualButton.Checked)
            {
                // Individual: Add the individual to the customer database
                bool customerAdded = customerController.CreateCustomer(customerId, firstName, lastName, email, mobileNumber, street, town, city, postCode);

                if (customerAdded)
                {
                    // Create the reservation for the individualcr
                    Console.WriteLine("creating reservation");
                    Reservation res = reservationController.CreateReservation(reservationId, customerId, "Standard Room", DateTime.Now, checkInDate, checkOutDate, numberOfPeople, totalPrice);
                    Console.WriteLine("reservaion Created");
                    if (res != null)
                    {
                        // Proceed to payment form
                        this.Visible = false;
                        //CreditCardDetailsForm creditCardDetailsForm = new CreditCardDetailsForm(reservationId, customerId, checkInDate, checkOutDate, totalPrice, "Pending");
                        CreditCardDetailsForm creditCardDetailsForm = new CreditCardDetailsForm(res, reservationController, email);
                        creditCardDetailsForm.MdiParent = this.MdiParent;
                        creditCardDetailsForm.WindowState = FormWindowState.Normal;
                        creditCardDetailsForm.Show();
                    }

                }

            }
        }

        private bool ValidateFields()
        {
            bool allFieldsValid = true;

            // Validate all required fields and update corresponding labels
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
            {
                HighlightLabel(Fnamelabel);
                allFieldsValid = false;
            }
            if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
            {
                HighlightLabel(Lnamelabel);
                allFieldsValid = false;
            }
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                HighlightLabel(emaillabel);
                allFieldsValid = false;
            }
            if (string.IsNullOrWhiteSpace(mobileTextBox.Text))
            {
                HighlightLabel(mobilenumberlabel);
                allFieldsValid = false;
            }
            if (string.IsNullOrWhiteSpace(streetTextBox.Text))
            {
                HighlightLabel(Streetlabel);
                allFieldsValid = false;
            }
            if (string.IsNullOrWhiteSpace(townTextBox.Text))
            {
                HighlightLabel(townlabel);
                allFieldsValid = false;
            }
            if (string.IsNullOrWhiteSpace(cityTextBox.Text))
            {
                HighlightLabel(citylabel);
                allFieldsValid = false;
            }
            if (string.IsNullOrWhiteSpace(postCodeTextBox.Text))
            {
                HighlightLabel(postcodelabel);
                allFieldsValid = false;
            }

            return allFieldsValid;
        }

        private void HighlightLabel(Label label)
        {
            label.ForeColor = Color.Red;
        }

        private void ResetLabelColor(object sender, EventArgs e)
        {
            // Reset the label color back to black when the user types in the associated TextBox
            if (sender == firstNameTextBox) Fnamelabel.ForeColor = Color.Black;
            if (sender == lastNameTextBox) Lnamelabel.ForeColor = Color.Black;
            if (sender == emailTextBox) emaillabel.ForeColor = Color.Black;
            if (sender == mobileTextBox) mobilenumberlabel.ForeColor = Color.Black;
            if (sender == streetTextBox) Streetlabel.ForeColor = Color.Black;
            if (sender == townTextBox) townlabel.ForeColor = Color.Black;
            if (sender == cityTextBox) citylabel.ForeColor = Color.Black;
            if (sender == postCodeTextBox) postcodelabel.ForeColor = Color.Black;
        }

        private async Task BlinkLabels()
        {
            // Blink the labels of the invalid fields three times
            for (int i = 0; i < 3; i++)
            {
                foreach (Control control in this.Controls)
                {
                    if (control is Label label && label.ForeColor == Color.Red)
                    {
                        label.ForeColor = Color.DarkRed;
                    }
                }

                await Task.Delay(200); // Wait for 200 ms

                foreach (Control control in this.Controls)
                {
                    if (control is Label label && label.ForeColor == Color.DarkRed)
                    {
                        label.ForeColor = Color.Red;
                    }
                }

                await Task.Delay(200); // Wait for 200 ms
            }
        }

        private void GuestDetails_Load(object sender, EventArgs e)
        {
            ClearFormFields();
            proceedtopayment.Text = "Proceed to Payment";
        }

        private void ClearFormFields()
        {
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            emailTextBox.Text = "";
            mobileTextBox.Text = "";
            streetTextBox.Text = "";
            townTextBox.Text = "";
            cityTextBox.Text = "";
            postCodeTextBox.Text = "";

            ResetLabelColors();
            ToggleFormFieldsVisibility(false);
        }

        private void ResetLabelColors()
        {
            Fnamelabel.ForeColor = Color.Black;
            Lnamelabel.ForeColor = Color.Black;
            emaillabel.ForeColor = Color.Black;
            mobilenumberlabel.ForeColor = Color.Black;
            Streetlabel.ForeColor = Color.Black;
            townlabel.ForeColor = Color.Black;
            citylabel.ForeColor = Color.Black;
            postcodelabel.ForeColor = Color.Black;
        }

        private void ToggleFormFieldsVisibility(bool isVisible)
        {
            Fnamelabel.Visible = isVisible;
            firstNameTextBox.Visible = isVisible;
            Lnamelabel.Visible = isVisible;
            lastNameTextBox.Visible = isVisible;
            emaillabel.Visible = isVisible;
            emailTextBox.Visible = isVisible;
            countrycodelabel.Visible = isVisible;
            countryCodecomboBox.Visible = isVisible;
            mobilenumberlabel.Visible = isVisible;
            mobileTextBox.Visible = isVisible;
            billingaddrlabel.Visible = isVisible;
            Streetlabel.Visible = isVisible;
            streetTextBox.Visible = isVisible;
            townlabel.Visible = isVisible;
            townTextBox.Visible = isVisible;
            citylabel.Visible = isVisible;
            cityTextBox.Visible = isVisible;
            postcodelabel.Visible = isVisible;
            postCodeTextBox.Visible = isVisible;
        }

        private void agentradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (agentradioButton.Checked)
            {
                SetFormLabelsForAgent();
                proceedtopayment.Text = "Proceed";
                ToggleFormFieldsVisibility(true);
            }
        }

        private void individualradioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (individualButton.Checked)
            {
                SetFormLabelsForIndividual();
                proceedtopayment.Text = "Proceed to Payment";
                ToggleFormFieldsVisibility(true);
            }
        }

        private void SetFormLabelsForAgent()
        {
            Fnamelabel.Text = "Agency Name";
            Lnamelabel.Text = "Agent ID";
            emaillabel.Text = "Agent Email";
            mobilenumberlabel.Text = "Agent Telephone Number";
            ToggleFormFieldsVisibility(true);
        }

        private void SetFormLabelsForIndividual()
        {
            Fnamelabel.Text = "First Name";
            Lnamelabel.Text = "Last Name";
            emaillabel.Text = "Email Address";
            mobilenumberlabel.Text = "Mobile Number";
            ToggleFormFieldsVisibility(true);
        }

        private void postCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            // Additional logic if needed
        }

    }
}
