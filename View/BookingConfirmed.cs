using Phumla_Kamnandi;
using Phumpla_Kamnandi.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Phumpla_Kamnandi.View
{
    public partial class BookingConfirmed : Form
    {
        
        private ReservationController reservationController;
        private string reservationId;
        private DateTime checkInTime;
        private DateTime checkOutTime;
        private decimal totalPrice;
        private string Status;
        private string email;
        public BookingConfirmed(string reservationId, DateTime checkInTime, DateTime checkOutTime, decimal totalPrice, string Status, string email)
        {
            InitializeComponent();
            this.reservationId = reservationId;
            this.checkInTime = checkInTime;
            this.checkOutTime = checkOutTime;
            this.totalPrice = totalPrice;
            this.Status = Status;
            this.email = email;
        }

        private void BookingConfirmed_Load(object sender, EventArgs e)
        {
            bookingNumlabel.Text = reservationId;
            checkInDatelabel.Text = checkInTime.ToString("dd MMM yyyy");
            checkOutDatelabel.Text = checkOutTime.ToString("dd MMM yyyy");
            totalAmtlabel.Text = totalPrice.ToString();
            StatusClabel.Text = Status;

            SendConfirmationEmail();
        }

        private void SendConfirmationEmail()
        {
            try
            {
                string fromEmail = "phumlakamnandi7@gmail.com";
                string fromPassword = "uibi ejjc efms hqaj";

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress(fromEmail);
                message.To.Add(new MailAddress(email));
                message.Subject = "Reservation Confirmation";
                message.Body = $"Dear Guest,\n\nYour reservation has been confirmed.\n\n" +
                               $"Reservation ID: {reservationId}\n" +
                               $"Check-in Date: {checkInTime.ToString("dd MMM yyyy")}\n" +
                               $"Check-out Date: {checkOutTime.ToString("dd MMM yyyy")}\n" +
                               $"Total Price: {totalPrice}\n" +
                               $"Status: {Status}\n\n" +
                               $"Thank you for choosing our service.\n\n" +
                               $"Best regards,\nPhumla Kamnandi";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; // This is for Gmail. Adjust if using a different email provider
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ReservationChangedEmail()
        {
            try
            {
                string fromEmail = "phumlakamnandi7@gmail.com";
                string fromPassword = "uibi ejjc efms hqaj";

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress(fromEmail);
                message.To.Add(new MailAddress(email));
                message.Subject = "Reservation Changed";
                message.Body = $"Dear Guest,\n\nYour reservation has been changed as requested.\n\n" +
                               $"Reservation ID: {reservationId}\n" +
                               $"Check-in Date: {checkInTime.ToString("dd MMM yyyy")}\n" +
                               $"Check-out Date: {checkOutTime.ToString("dd MMM yyyy")}\n" +
                               $"Total Price: {totalPrice}\n" +
                               $"Status: {Status}\n\n" +
                               $"Thank you for choosing our service.\n\n" +
                               $"Best regards,\nPhumla Kamnandi";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; // This is for Gmail. Adjust if using a different email provider
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(message);

                //MessageBox.Show("Confirmation email sent successfully!", "Email Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       

        

        private void okaybutton_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            HomePage homePage = new HomePage();
            homePage.MdiParent = this.MdiParent;
            homePage.WindowState = FormWindowState.Normal;
            homePage.Show();
        }
    }
}
