using Phumpla_Kamnandi.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;


namespace Phumpla_Kamnandi.View
{
    public partial class SelectRoomForm : Form
    {

        private DateTime checkInDate;
        private DateTime checkOutDate;
        private decimal totalPrice;
        private string totalPeople;
        private int availableRoomsCount;
        private RoomController roomsController;

        public SelectRoomForm(DateTime checkInDate, DateTime checkOutDate, decimal totalPrice)
        {
            InitializeComponent();
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.totalPrice = totalPrice;
            roomsController = new RoomController();
            Collection<Room> availableRooms = roomsController.GetAvailableRooms(checkInDate, checkOutDate);
            availableRoomsCount = availableRooms.Count;
        }

        private void UpdateRoomDetails(object sender, EventArgs e)
        {
            LimitRoomCapacity();
            UpdateTotalPrice();
        }

        private void LimitRoomCapacity()
        {
            LimitSingleRoomCapacity(adults1numericUpDown, child1rennumericUpDown, toddlers1numericUpDown);
            if (adults2numericUpDown.Visible)
                LimitSingleRoomCapacity(adults2numericUpDown, child2rennumericUpDown, toddlers2numericUpDown);
            if (adults3numericUpDown.Visible)
                LimitSingleRoomCapacity(adults3numericUpDown, child3rennumericUpDown, toddlers3numericUpDown);
            if (adults4numericUpDown.Visible)
                LimitSingleRoomCapacity(adults4numericUpDown, child4rennumericUpDown, toddlers4numericUpDown);
            if (adults5numericUpDown.Visible)
                LimitSingleRoomCapacity(adults5numericUpDown, child5rennumericUpDown, toddlers5numericUpDown);
        }

        private void LimitSingleRoomCapacity(NumericUpDown adults, NumericUpDown children, NumericUpDown toddlers)
        {
            int totalOccupants = (int)(adults.Value + children.Value + toddlers.Value);
            const int MaxOccupants = 4;

            if (totalOccupants > MaxOccupants)
            {
                // Determine which control triggered the change
                NumericUpDown changedControl = (NumericUpDown)adults.Tag;
                if (changedControl == null)
                {
                    // If tag is not set, assume the last changed control
                    if (toddlers.Focused) changedControl = toddlers;
                    else if (children.Focused) changedControl = children;
                    else changedControl = adults;
                }

                // Adjust the value of the changed control
                changedControl.Value = Math.Max(0, changedControl.Value - (totalOccupants - MaxOccupants));

                MessageBox.Show($"This room can accommodate a maximum of {MaxOccupants} people.", "Room Capacity Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Reset the tag
            adults.Tag = null;
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Set the tag to remember which control changed
            ((NumericUpDown)sender).Parent.Controls.OfType<NumericUpDown>().First(nud => nud.Name.StartsWith("adults")).Tag = sender;
            UpdateRoomDetails(sender, e);
        }

        private void Adultslabel_Click(object sender, EventArgs e)
        {

        }

        private void roomsnumericUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            int selectedRooms = (int)roomsnumericUpDown.Value;

            if (selectedRooms > availableRoomsCount)
            {
                MessageBox.Show($"Sorry, only {availableRoomsCount} rooms are available for the selected dates.",
                                "Room Availability",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                roomsnumericUpDown.Value = availableRoomsCount;
                selectedRooms = availableRoomsCount;
            }

            HideAllRoomControls();

            for (int i = 2; i <= selectedRooms; i++)
            {
                ShowRoomControls(i);
            }

            UpdateTotalPrice();
        }

        private void HideAllRoomControls()
        {
            room2label.Visible = false;
            room3label.Visible = false;
            room4label.Visible = false;
            room5label.Visible = false;

            adults2numericUpDown.Visible = false;
            adults3numericUpDown.Visible = false;
            adults4numericUpDown.Visible = false;
            adults5numericUpDown.Visible = false;

            child2rennumericUpDown.Visible = false;
            child3rennumericUpDown.Visible = false;
            child4rennumericUpDown.Visible = false;
            child5rennumericUpDown.Visible = false;

            toddlers2numericUpDown.Visible = false;
            toddlers3numericUpDown.Visible = false;
            toddlers4numericUpDown.Visible = false;
            toddlers5numericUpDown.Visible = false;
        }

        private void ShowRoomControls(int roomNumber)
        {
            switch (roomNumber)
            {
                case 2:
                    room2label.Visible = true;
                    adults2numericUpDown.Visible = true;
                    child2rennumericUpDown.Visible = true;
                    toddlers2numericUpDown.Visible = true;
                    break;
                case 3:
                    room3label.Visible = true;
                    adults3numericUpDown.Visible = true;
                    child3rennumericUpDown.Visible = true;
                    toddlers3numericUpDown.Visible = true;
                    break;
                case 4:
                    room4label.Visible = true;
                    adults4numericUpDown.Visible = true;
                    child4rennumericUpDown.Visible = true;
                    toddlers4numericUpDown.Visible = true;
                    break;
                case 5:
                    room5label.Visible = true;
                    adults5numericUpDown.Visible = true;
                    child5rennumericUpDown.Visible = true;
                    toddlers5numericUpDown.Visible = true;
                    break;
            }
        }

        private void UpdateTotalPrice()
        {

            // Calculate the total price
            decimal calculatedTotalPrice = 0;

            // Iterate through each room and calculate the price based on the number of people
            calculatedTotalPrice += CalculateRoomPrice(adults1numericUpDown.Value, child1rennumericUpDown.Value, toddlers1numericUpDown.Value);

            if (adults2numericUpDown.Visible)
                calculatedTotalPrice += CalculateRoomPrice(adults2numericUpDown.Value, child2rennumericUpDown.Value, toddlers2numericUpDown.Value);

            if (adults3numericUpDown.Visible)
                calculatedTotalPrice += CalculateRoomPrice(adults3numericUpDown.Value, child3rennumericUpDown.Value, toddlers3numericUpDown.Value);

            if (adults4numericUpDown.Visible)
                calculatedTotalPrice += CalculateRoomPrice(adults4numericUpDown.Value, child4rennumericUpDown.Value, toddlers4numericUpDown.Value);

            if (adults5numericUpDown.Visible)
                calculatedTotalPrice += CalculateRoomPrice(adults5numericUpDown.Value, child5rennumericUpDown.Value, toddlers5numericUpDown.Value);

            // Display the total calculated price
            totalpricelabel.Text = calculatedTotalPrice.ToString();
        }


        // Method to calculate the price for each room based on adults, children, and toddlers
        private decimal CalculateRoomPrice(decimal adults, decimal children, decimal toddlers)
        {
            decimal totalRoomPrice = 0;

            // Calculate the price for adults (full price)
            totalRoomPrice += adults * totalPrice;

            // Calculate the price for children (half price)
            totalRoomPrice += (children * totalPrice) / 2;


            // Check if the total number of people exceeds 4
            if (adults + children + toddlers > 4)
            {
                MessageBox.Show("Too many people for this room, consider booking an additional room.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return totalRoomPrice;
        }

        private void SelectRoomForm_Load(object sender, EventArgs e)
        {
            totalpricelabel.Text = totalPrice.ToString();

            HideAllRoomControls();

            // Attach the ValueChanged event to all relevant NumericUpDown controls
            adults1numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            adults2numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            adults3numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            adults4numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            adults5numericUpDown.ValueChanged += NumericUpDown_ValueChanged;

            child1rennumericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            child2rennumericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            child3rennumericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            child4rennumericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            child5rennumericUpDown.ValueChanged += NumericUpDown_ValueChanged;

            toddlers1numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            toddlers2numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            toddlers3numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            toddlers4numericUpDown.ValueChanged += NumericUpDown_ValueChanged;
            toddlers5numericUpDown.ValueChanged += NumericUpDown_ValueChanged;

            // Set rooms numeric up/down to start with 1 room selected by default
            roomsnumericUpDown.Value = 1;
        }

       
        private void CalculateTotalPeople()
        {
            int totalPeople_ = 0;

            totalPeople_ += (int)(adults1numericUpDown.Value + child1rennumericUpDown.Value + toddlers1numericUpDown.Value);

            if (adults2numericUpDown.Visible)
                totalPeople_ += (int)(adults2numericUpDown.Value + child2rennumericUpDown.Value + toddlers2numericUpDown.Value);

            if (adults3numericUpDown.Visible)
                totalPeople_ += (int)(adults3numericUpDown.Value + child3rennumericUpDown.Value + toddlers3numericUpDown.Value);

            if (adults4numericUpDown.Visible)
                totalPeople_ += (int)(adults4numericUpDown.Value + child4rennumericUpDown.Value + toddlers4numericUpDown.Value);

            if (adults5numericUpDown.Visible)
                totalPeople_ += (int)(adults5numericUpDown.Value + child5rennumericUpDown.Value + toddlers5numericUpDown.Value);


            totalPeople = totalPeople_.ToString();
        }

        private void booknowbtn_Click(object sender, EventArgs e)
        {
            // Calculate the total number of people
            CalculateTotalPeople();
            

            this.Visible = false;

            totalPrice = decimal.Parse(totalpricelabel.Text);

            GuestDetails guestDetails = new GuestDetails(totalPrice, checkInDate, checkOutDate, totalPeople);
            guestDetails.MdiParent = this.MdiParent;
            guestDetails.WindowState = FormWindowState.Normal;
            guestDetails.Show();
        }

        private void totalpricelabel_Click(object sender, EventArgs e)
        {

        }
    }
}
