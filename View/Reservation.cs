using Phumpla_Kamnandi.Application;
using Phumpla_Kamnandi.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reservations
{
    public partial class ReservationForm : Form
    {
        private RoomController roomController;
        private decimal lowSeasonPrice = 550;
        private decimal midSeasonPrice = 750m;
        private decimal highSeasonPrice = 995m;

        private DateTime initialCheckInDate;
        private DateTime initialCheckOutDate;

        public ReservationForm()
        {
            InitializeComponent();

            roomController = new RoomController();

            // Set the minimum date for dateTimePickerFrom to today
            dateTimePickerFrom.MinDate = DateTime.Today;

            // Disable the dateTimePickerTo initially
            dateTimePickerTo.Enabled = false;

            // Set the maximum date for dateTimePickerTo to the end of the current year
            dateTimePickerTo.MaxDate = new DateTime(DateTime.Today.Year, 12, 31);

            initialCheckInDate = dateTimePickerFrom.Value;
            initialCheckOutDate = dateTimePickerTo.Value;

            // Event handler for when the value of dateTimePickerFrom changes
            dateTimePickerFrom.ValueChanged += dateTimePickerFrom_ValueChanged;

            // Disable search and reservation buttons initially
            searchButton.Enabled = false;
            makeReservationbtn.Enabled = false;
        }

        // Method to initialize placeholder text for both textboxes
        private void Form1_Load(object sender, EventArgs e)
        {
            makeReservationbtn.Enabled = false;
            searchButton.Enabled = false;
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e)
        {
            // Set dateTimePickerTo's MinDate to the selected date from dateTimePickerFrom
            dateTimePickerTo.MinDate = dateTimePickerFrom.Value;

            // Automatically set dateTimePickerTo to the next day and enable it
            dateTimePickerTo.Value = dateTimePickerFrom.Value.AddDays(1);
            dateTimePickerTo.Enabled = true;

            // Enable the search button
            searchButton.Enabled = true;
        }

        private void roomsAvailableTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // Get the selected dates from the date pickers
            DateTime checkInDate = dateTimePickerFrom.Value;
            DateTime checkOutDate = dateTimePickerTo.Value;

            // Fetch available rooms using RoomController
            var availableRooms = roomController.GetAvailableRooms(checkInDate, checkOutDate);

            // Clear previous results
            roomsAvailableTextBox.Clear();

            // Display the available rooms in the roomsAvailableTextBox
            DisplayAvailableRooms(availableRooms, checkInDate, checkOutDate);

            makeReservationbtn.Enabled = true;
        }

        private decimal GetPriceBasedOnSeason(DateTime checkInDate, DateTime checkOutDate)
        {
            decimal totalPrice = 0;

            // Loop through each day in the range from check-in to check-out
            for (DateTime date = checkInDate; date < checkOutDate; date = date.AddDays(1))
            {
                if (date >= new DateTime(date.Year, 12, 1) && date <= new DateTime(date.Year, 12, 7))
                {
                    totalPrice += lowSeasonPrice;
                }
                else if (date >= new DateTime(date.Year, 12, 8) && date <= new DateTime(date.Year, 12, 15))
                {
                    totalPrice += midSeasonPrice;
                }
                else if (date >= new DateTime(date.Year, 12, 16) && date <= new DateTime(date.Year, 12, 31))
                {
                    totalPrice += highSeasonPrice;
                }
                else
                {
                    totalPrice += lowSeasonPrice;
                }
            }

            return totalPrice;
        }


        // Method to display available rooms in the TextBox and apply pricing based on the season
        private void DisplayAvailableRooms(Collection<Room> availableRooms, DateTime checkInDate, DateTime checkOutDate)
        {
            if (availableRooms.Count > 0)
            {
                decimal roomPriceForStay = GetPriceBasedOnSeason(checkInDate, checkOutDate);

                // Display each available room on a new line
                foreach (var room in availableRooms)
                {
                    // Format: "Room Number: {RoomNumber}, Type: {RoomType}, Price: {Calculated Price}"
                    string roomDetails = $"Room Number: {room.RoomNumber}, Type: {room.RoomType}, Price for stay: R{roomPriceForStay}";
                    roomsAvailableTextBox.AppendText(roomDetails + Environment.NewLine);
                }
            }
            else
            {
                // If no rooms are available, show a message
                roomsAvailableTextBox.AppendText("No rooms available for the selected dates.");
            }
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void makeReservationbtn_Click(object sender, EventArgs e)
        {
            DateTime checkInDate = dateTimePickerFrom.Value;
            DateTime checkOutDate = dateTimePickerTo.Value;
            decimal totalPrice = GetPriceBasedOnSeason(checkInDate, checkOutDate); // Assuming you calculate total price here
            this.Visible = false;

            SelectRoomForm selectRoomForm = new SelectRoomForm(checkInDate, checkOutDate, totalPrice);
            selectRoomForm.MdiParent = this.MdiParent;
            selectRoomForm.WindowState = FormWindowState.Normal;
            selectRoomForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Reset date pickers to their initial values
            dateTimePickerFrom.Value = DateTime.Today;
            dateTimePickerTo.Value = DateTime.Today.AddDays(1); // Set To date to the day after From date

            // Disable search button and reset other fields
            makeReservationbtn.Enabled = false;
            roomsAvailableTextBox.Clear();
        }
    }
}
