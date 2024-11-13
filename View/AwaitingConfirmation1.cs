using Phumla_Kamnandi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumpla_Kamnandi.View
{
    public partial class AwaitingConfirmation : Form
    {
        private string reservationId;
        private DateTime checkInTime;
        private DateTime checkOutTime;
        private decimal totalPrice;
        private string Status;
        private string Email;
        public AwaitingConfirmation(string reservationId, DateTime checkInTime, DateTime checkOutTime, decimal totalPrice, string Status, string Email)
        {
            InitializeComponent();
            this.reservationId = reservationId;
            this.checkInTime = checkInTime;
            this.checkOutTime = checkOutTime;
            this.totalPrice = totalPrice;
            this.Status = Status;
            this.Email = Email;
        }

        private void AwaitingConfirmation_Load(object sender, EventArgs e)
        {
            bookingNumlabel.Text = reservationId;
            checkInDatelabel.Text = checkInTime.ToString();
            checkOutDatelabel.Text = checkOutTime.ToString();
            totalAmtlabel.Text = totalPrice.ToString();
            StatusClabel.Text = Status;
            Emaillabel.Text = Email;
        }

        private void okaybutton_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;

            HomePage homePage = new HomePage();
            homePage.MdiParent = this.MdiParent;
            homePage.WindowState = FormWindowState.Normal;
            homePage.Show();
        }
    }
}
