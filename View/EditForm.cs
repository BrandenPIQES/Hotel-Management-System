using Phumla_Kamnandi;
using Phumpla_Kamnandi.Application;
using Phumpla_Kamnandi.Data;
using Reservations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Phumpla_Kamnandi.View
{
    public partial class EditForm : Form
    {
        private Reservation reservation;
        private Customer customer;
        private ReservationController reservationController;
        private DateTime newCheckInDate;
        private DateTime newCheckOutDate;
        private RoomController roomController = new RoomController();
        private decimal totalPrice;
        private int maximumNumberOFPeopleFOReservation;
        Collection<Room> availableRooms;


        Collection<NumericUpDown> numericUpDownsForRoom1;
        Collection<NumericUpDown> numericUpDownsForRoom2;
        Collection<NumericUpDown> numericUpDownsForRoom3;
        Collection<NumericUpDown> numericUpDownsForRoom4;
        Collection<NumericUpDown> numericUpDownsForRoom5;
        public EditForm(Reservation res, Customer cus,ReservationController reservationController)
        {

            InitializeComponent();
            reservation = res;
            this.customer = cus;
            this.reservationController = reservationController;
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            firstNameLabel.Text = customer.FirstName;
            lastNameLabel.Text = customer.LastName;

            //checkInDatePicker.MinDate = DateTime.Today;
            checkInDatePicker.Value = reservation.CheckInDate;

            //checkOutDatePicker.MinDate = DateTime.Today;
            checkOutDatePicker.Value = reservation.CheckOutDate;
            roomTypeDropBox.Text = reservation.RoomType;
            DaysTextBox.Text = (DateTime.Today - reservation.ReservationDate.Date).TotalDays.ToString();
            DaysTextBox.Enabled = false;

            addNumericUpdowToCollection();
            SetupUpDownTextBox();

            if (reservation.Status.ToLower().Equals("confirmed"))
            {
                countAviableRooms();
                SetupUpDownTextBox();
                totalpricelabel.Text = "R0";
                addNumericUpdowToCollection();
            }
            else if (reservation.Status.ToLower().Equals("pending")) 
            {
              numberOfRoomsGroupBox.Visible = false;
              adultslabel.Visible = false;
              toddlerslabel.Visible = false;
              childrenlabel.Visible = false;
              room1label.Visible = false;
              room2label.Visible = false;
              room3label.Visible = false;
              room4label.Visible = false;
              room5label.Visible = false;
              roomTypeDropBox.Enabled = false;
              changeReservationButton.Visible = false;

            }
            else 
            {
                checkInDatePicker.Enabled = false;
                checkOutDatePicker.Enabled = false;
                numberOfRoomsGroupBox.Visible = false;
                adultslabel.Visible = false;
                toddlerslabel.Visible = false;
                childrenlabel.Visible = false;
                room1label.Visible = false;
                room2label.Visible = false;
                room3label.Visible = false;
                room4label.Visible = false;
                room5label.Visible = false;
                roomTypeDropBox.Enabled = false;
                changeReservationButton.Visible = false;
                cenceleReservationButton.Visible = false;
                totalpricelabel.Text = "This servation has been cancelled";

                // Calculate the x and y position to center the label at the bottom
                int xPosition = (this.ClientSize.Width - totalpricelabel.Width) / 2;
                int yPosition = this.ClientSize.Height - totalpricelabel.Height - 100; 

                totalpricelabel.Location = new System.Drawing.Point(xPosition, yPosition);

                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.Size = new Size(75, 30);
                okButton.Location = new Point((this.ClientSize.Width - okButton.Width) / 2, this.ClientSize.Height - okButton.Height - 10);
                okButton.Click += OkButton_Click;

                this.Controls.Add(okButton);
            }
        }

       
        private void OkButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void addNumericUpdowToCollection() 
        {
            numericUpDownsForRoom1 = new Collection<NumericUpDown> { };
            numericUpDownsForRoom2 = new Collection<NumericUpDown> { };
            numericUpDownsForRoom3 = new Collection<NumericUpDown> { };
            numericUpDownsForRoom4 = new Collection<NumericUpDown> { };
            numericUpDownsForRoom5  = new Collection<NumericUpDown> { };

            numericUpDownsForRoom1.Add(child1rennumericUpDown);
            numericUpDownsForRoom1.Add(adults1numericUpDown);
            numericUpDownsForRoom1.Add(toddlers1numericUpDown);

            numericUpDownsForRoom2.Add(child2rennumericUpDown);
            numericUpDownsForRoom2.Add(adults2numericUpDown);
            numericUpDownsForRoom2.Add(toddlers2numericUpDown);

            numericUpDownsForRoom3.Add(child3rennumericUpDown);
            numericUpDownsForRoom3.Add(adults3numericUpDown);
            numericUpDownsForRoom3.Add(toddlers3numericUpDown);

            numericUpDownsForRoom4.Add(child4rennumericUpDown);
            numericUpDownsForRoom4.Add(adults4numericUpDown);
            numericUpDownsForRoom4.Add(toddlers4numericUpDown);


            numericUpDownsForRoom5.Add(child5rennumericUpDown);
            numericUpDownsForRoom5.Add(adults5numericUpDown);
            numericUpDownsForRoom5.Add(toddlers5numericUpDown);
        }

        private void changeReservationButton_Click(object sender, EventArgs e)
        {  //   
            if (roomsnumericUpDown.Value == 0 )
            {
                MessageBox.Show("Please select a room", "No Selected Room", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               // MessageBox.Show("select new check in Date or check Out");
            }
            else if (availableRooms.Count == 0)
            {
                MessageBox.Show("Select Another date", "No Room Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                reservation.CheckInDate = newCheckInDate;
                reservation.CheckOutDate = newCheckOutDate;
                
                DialogResult result = MessageBox.Show("Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                  
                    // Insert code for proceeding with the action here
                    string totatNumberOfPeople = CalculateTotalPeople();
                    if(Int32.Parse(totatNumberOfPeople) > roomsnumericUpDown.Value * 4)
                    {
                        MessageBox.Show($"You went of the maximum number of poeple for {roomsnumericUpDown.Value}", "Too Many People for Reservation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        reservation.CheckInDate = newCheckInDate;
                        reservation.CheckOutDate = newCheckOutDate;
                        UpdateTotalPrice();
                        reservation.NumOfPeople = CalculateTotalPeople();
                        reservation.TotalAmount = Int32.Parse( totalpricelabel.Text.Substring(1));

                        //reservation.Status = "Confirmed";
                        reservationController.DataMaintenance(reservation,DB.DBOperation.Edit);
                        reservationController.FinalizeChanges(reservation);

                        //this.Hide();
                        BookingConfirmed bookingConfirmed = new BookingConfirmed(reservation.ReservationID,reservation.CheckInDate,reservation.CheckOutDate,reservation.TotalAmount,reservation.Status,customer.Email);
                        bookingConfirmed.ReservationChangedEmail();
                        MessageBox.Show("Reservation was successfully updated and an email has been sent", "Reservation updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                   
                    }
                    
                   
                }
                else if (result == DialogResult.No)
                {
                    // The user clicked 'No')
                    MessageBox.Show("Action cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // Insert code to cancel the action here
                }

            }
        }
        public void countAviableRooms()
        {
            availableRooms = roomController.GetAvailableRooms(newCheckInDate, newCheckOutDate);
        }

        private void checkInDatePicker_ValueChanged(object sender, EventArgs e)
        {
            newCheckInDate = checkInDatePicker.Value;
            checkOutDatePicker.MinDate = newCheckInDate.Date.AddDays(1);
            checkOutDatePicker.Value = newCheckInDate.Date.AddDays(1);
            totalPrice = GetPriceBasedOnSeason(newCheckInDate, newCheckOutDate);
            countAviableRooms();
            UpdateTotalPrice();
        }

        private void checkOutDatePicker_ValueChanged(object sender, EventArgs e)
        {
            newCheckOutDate = checkOutDatePicker.Value;
            if (newCheckOutDate.Date < newCheckInDate.Date) {
                MessageBox.Show("Invalid checkout date");
                newCheckOutDate = checkInDatePicker.Value.AddDays(1);
                checkOutDatePicker.Value = checkInDatePicker.Value.AddDays(1);
            }
            totalPrice = GetPriceBasedOnSeason(newCheckInDate, newCheckOutDate);
            countAviableRooms();
            UpdateTotalPrice();
        }
            
        private void cenceleReservationButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cancel reservation?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                reservation.Status = "Cancelled";
                reservationController.DataMaintenance(reservation, Data.DB.DBOperation.Edit);
                reservationController.FinalizeChanges(reservation);
                MessageBox.Show("Resevation cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
   
                this.Close();


            }
            
        
            else if (result == DialogResult.No)
                {
                 // The user clicked 'No')
                 MessageBox.Show("Action cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 // Insert code to cancel the action here
                }
            
           
            
        }
        private void roomsnumericUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            int numberOfRooms = (int)roomsnumericUpDown.Value;
            if(numberOfRooms > availableRooms.Count)
            {
                MessageBox.Show($"maximum Number of rooms avaible for the reservation period is {availableRooms.Count}","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                numberOfRooms = availableRooms.Count;
                roomsnumericUpDown.Value = numberOfRooms;
            }
            // Hide all controls first
            room1label.Visible=false;
            room2label.Visible = false;
            room3label.Visible = false;
            room4label.Visible = false;
            room5label.Visible = false;

            adults1numericUpDown.Visible=false;
            adults2numericUpDown.Visible = false;
            adults3numericUpDown.Visible = false;
            adults4numericUpDown.Visible = false;
            adults5numericUpDown.Visible = false;

            child1rennumericUpDown.Visible=false;
            child2rennumericUpDown.Visible = false;
            child3rennumericUpDown.Visible = false;
            child4rennumericUpDown.Visible = false;
            child5rennumericUpDown.Visible = false;

            toddlers1numericUpDown.Visible = false;
            toddlers2numericUpDown.Visible = false;
            toddlers3numericUpDown.Visible = false;
            toddlers4numericUpDown.Visible = false;
            toddlers5numericUpDown.Visible = false;

            // Now show controls based on selected rooms
            switch (numberOfRooms)
            {
                case 1:
                    room1label.Visible = true;
                    adults1numericUpDown.Visible = true;
                    child1rennumericUpDown.Visible = true;
                    toddlers1numericUpDown.Visible =   true;
                    break;
                case 2:
                    // Show room 1 and 2 controls

                    room1label.Visible = true;
                    adults1numericUpDown.Visible = true;
                    child1rennumericUpDown.Visible = true;
                    toddlers1numericUpDown.Visible = true;

                    room2label.Visible = true;
                    adults2numericUpDown.Visible = true;
                    child2rennumericUpDown.Visible = true;
                    toddlers2numericUpDown.Visible = true;
                    break;

                case 3:
                    // Show room 1, 2, and 3 controls
                    room2label.Visible = true;
                    room3label.Visible = true;
                    room1label.Visible = true;


                    adults1numericUpDown.Visible = true;
                    child1rennumericUpDown.Visible = true;
                    toddlers1numericUpDown.Visible = true;

                    adults2numericUpDown.Visible = true;
                    adults3numericUpDown.Visible = true;

                    child2rennumericUpDown.Visible = true;
                    child3rennumericUpDown.Visible = true;

                    toddlers2numericUpDown.Visible = true;
                    toddlers3numericUpDown.Visible = true;
                    break;

                case 4:
                    // Show room 1, 2, 3, and 4 controls
                    room2label.Visible = true;
                    room3label.Visible = true;
                    room4label.Visible = true;
                    room1label.Visible = true;

                    adults1numericUpDown.Visible = true;
                    child1rennumericUpDown.Visible = true;
                    toddlers1numericUpDown.Visible = true;

                    adults2numericUpDown.Visible = true;
                    adults3numericUpDown.Visible = true;
                    adults4numericUpDown.Visible = true;

                    child2rennumericUpDown.Visible = true;
                    child3rennumericUpDown.Visible = true;
                    child4rennumericUpDown.Visible = true;

                    toddlers2numericUpDown.Visible = true;
                    toddlers3numericUpDown.Visible = true;
                    toddlers4numericUpDown.Visible = true;
                    break;

                case 5:
                    // Show room 1, 2, 3, 4, and 5 controls
                    room2label.Visible = true;
                    room3label.Visible = true;
                    room4label.Visible = true;
                    room5label.Visible = true;
                    room1label.Visible = true;

                    adults1numericUpDown.Visible = true;
                    child1rennumericUpDown.Visible = true;
                    toddlers1numericUpDown.Visible = true;

                    adults2numericUpDown.Visible = true;
                    adults3numericUpDown.Visible = true;
                    adults4numericUpDown.Visible = true;
                    adults5numericUpDown.Visible = true;

                    child2rennumericUpDown.Visible = true;
                    child3rennumericUpDown.Visible = true;
                    child4rennumericUpDown.Visible = true;
                    child5rennumericUpDown.Visible = true;

                    toddlers2numericUpDown.Visible = true;
                    toddlers3numericUpDown.Visible = true;
                    toddlers4numericUpDown.Visible = true;
                    toddlers5numericUpDown.Visible = true;
                    break;
            }

            // Call the price update whenever room count is changed
            UpdateTotalPrice();
        }
        
        private void UpdateTotalPrice()
        {

            // Calculate the total price
            decimal calculatedTotalPrice = 0;

            // Iterate through each room and calculate the price based on the number of people
            if(adults1numericUpDown.Visible)
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
            totalpricelabel.Text =  "R"+calculatedTotalPrice.ToString();
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
                MessageBox.Show("Too many people for this room, consider booking an additional room", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return totalRoomPrice;
        }
        private decimal GetPriceBasedOnSeason(DateTime checkInDate, DateTime checkOutDate)
        {
             decimal lowSeasonPrice = 550;
             decimal midSeasonPrice = 750;
             decimal highSeasonPrice = 995;
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
        private void SetupUpDownTextBox()
        {
            ///alll hiden
            room1label.Visible = false;
            room2label.Visible = false;
            room3label.Visible = false;
            room4label.Visible = false;
            room5label.Visible = false;

            adults1numericUpDown.Visible = false;
            adults2numericUpDown.Visible = false;
            adults3numericUpDown.Visible = false;
            adults4numericUpDown.Visible = false;
            adults5numericUpDown.Visible = false;

            child1rennumericUpDown.Visible = false;
            child2rennumericUpDown.Visible = false;
            child3rennumericUpDown.Visible = false;
            child4rennumericUpDown.Visible = false;
            child5rennumericUpDown.Visible = false;

            toddlers1numericUpDown.Visible = false;
            toddlers2numericUpDown.Visible = false;
            toddlers3numericUpDown.Visible = false;
            toddlers4numericUpDown.Visible = false;
            toddlers5numericUpDown.Visible = false;

            // Attach the ValueChanged event to all relevant NumericUpDown controls
            adults1numericUpDown.ValueChanged += UpdateRoomDetails;
            adults2numericUpDown.ValueChanged += UpdateRoomDetails;
            adults3numericUpDown.ValueChanged += UpdateRoomDetails;
            adults4numericUpDown.ValueChanged += UpdateRoomDetails;
            adults5numericUpDown.ValueChanged += UpdateRoomDetails;

            child1rennumericUpDown.ValueChanged += UpdateRoomDetails;
            child2rennumericUpDown.ValueChanged += UpdateRoomDetails;
            child3rennumericUpDown.ValueChanged += UpdateRoomDetails;
            child4rennumericUpDown.ValueChanged += UpdateRoomDetails;
            child5rennumericUpDown.ValueChanged += UpdateRoomDetails;

            toddlers1numericUpDown.ValueChanged += UpdateRoomDetails;
            toddlers2numericUpDown.ValueChanged += UpdateRoomDetails;
            toddlers3numericUpDown.ValueChanged += UpdateRoomDetails;
            toddlers4numericUpDown.ValueChanged += UpdateRoomDetails;
            toddlers5numericUpDown.ValueChanged += UpdateRoomDetails;

            
        }

        // This method will call UpdateTotalPrice whenever a numeric up/down control changes
        private void UpdateRoomDetails(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            Collection<NumericUpDown> numericUpDownsForRoom = numericUpDownsForRooms(numericUpDown);
            int room = WhichRoom(numericUpDown);
            if (!isOverMaxForRoom(numericUpDownsForRoom))
            {
                MessageBox.Show($"consider adding another room", $"Too many People in Room {room}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown.Value -= 1;
            }
            else { UpdateTotalPrice(); }


            
            
            
        }
        #region CHECKING IF A PARTICULAR ROOM DOES NOT HAVE MORE THAN 4 PEAOPLE
        private bool isOverMaxForRoom(Collection<NumericUpDown> numericUpDownsForRooms)
        {
            decimal totalNumberOfChosenPeople = 0;
            foreach (NumericUpDown numericUpDown in numericUpDownsForRooms)
            {
                totalNumberOfChosenPeople += numericUpDown.Value;
            }
            if (totalNumberOfChosenPeople > 4) { return false; }
            else { return true; }
        }
        public Collection<NumericUpDown> numericUpDownsForRooms(NumericUpDown numericUpDown)
        {
            if (numericUpDownsForRoom1.Contains(numericUpDown)) { return numericUpDownsForRoom1; }
            else if (numericUpDownsForRoom2.Contains(numericUpDown)) { return numericUpDownsForRoom2; }
            else if (numericUpDownsForRoom3.Contains(numericUpDown)) { return numericUpDownsForRoom3; }
            else if (numericUpDownsForRoom4.Contains(numericUpDown)) { return numericUpDownsForRoom4; }
            else if (numericUpDownsForRoom5.Contains(numericUpDown)) { return numericUpDownsForRoom5; }
            else { return null; }

        }
        public int WhichRoom(NumericUpDown numericUpDown) 
        {
            if (numericUpDownsForRoom1.Contains(numericUpDown)) { return 1; }
            else if (numericUpDownsForRoom2.Contains(numericUpDown)) { return 2; }
            else if(numericUpDownsForRoom3.Contains(numericUpDown)) {  return 3; }
            else if( numericUpDownsForRoom4.Contains(numericUpDown)) { return 4; }
            else {return 5; }

        }
        #endregion
        private string CalculateTotalPeople()
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


            return totalPeople_.ToString();
        }
    }
}
