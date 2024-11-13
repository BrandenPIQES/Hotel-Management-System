using Phumpla_Kamnandi.Application;
using Phumpla_Kamnandi.Data;
using Phumpla_Kamnandi.View;
using Reservations;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Phumla_Kamnandi
{
    public partial class HomePage : Form
    {
        enum ViewState
        {
            bookings,
            rooms,
            guests,
        }
        private CustomerController customerController;
        private EmployeeController employeeController;
        private ReservationController reservationController;
        private RoomController roomController;
        private Collection<Customer> customers;
        private Collection<Reservation> reservations;
        private Collection<Room> rooms;
        private Reservation reservation;
        private Customer Customer;
        private Employee currentEmployee;
        private string employeeID;

        private ViewState viewState;
        

        public HomePage()
        {
            customerController = new CustomerController();
            customers = customerController.AllCustomers;
            reservationController = new ReservationController();
            reservations = reservationController.AllReservations;
            roomController = new RoomController();
            employeeController = new EmployeeController();
            rooms = roomController.AllRooms;
            this.employeeID = employeeID;
            this.currentEmployee = SessionManager.CurrentEmployee;
            InitializeComponent();
            initializeButtons();

        }

        /*public HomePage()
        {
            customerController = new CustomerController();
            customers = customerController.AllCustomers;
            reservationController = new ReservationController();
            reservations = reservationController.AllReservations;
            roomController = new RoomController();
            employeeController = new EmployeeController();
            rooms = roomController.AllRooms;
            InitializeComponent();
            initializeButtons();

        }*/


        public void initializeButtons()
        {
            guestButton.FlatAppearance.BorderSize = 0;
            bookingsButton.FlatAppearance.BorderSize = 0;
            reservationButton.FlatAppearance.BorderSize = 0;
            roomButton.FlatAppearance.BorderSize = 0;
            signOutButton.FlatAppearance.BorderSize = 0;
            SearchButton.FlatAppearance.BorderSize = 0;
            editButton.FlatAppearance.BorderSize = 0;
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void setUpListView()
        {
            editButton.Visible = false;
            switch(viewState){
                case ViewState.bookings:
                    setUpListViewForBookings();
                    break;
                case ViewState.guests:
                    setUpListViewForCustomer();
                    break;
                case ViewState.rooms:
                    setUpListViewsForRooms();
                    break;
            }
        }

      

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key was pressed
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("applesl");
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MessageBox.Show("apples");
                e.SuppressKeyPress = true; // Prevent the "ding" sound on pressing Enter
                //PerformSearch(); // Call your search logic here
            }
        }

        private void bookingsButton_Click(object sender, EventArgs e)  { viewState = ViewState.bookings; setUpListView(); }


        private void reservationButton_Click(object sender, EventArgs e)
        {
            this.Visible = false; 

            ReservationForm reservationForm = new ReservationForm();
            reservationForm.MdiParent = this.MdiParent;
            reservationForm.WindowState = FormWindowState.Normal;
            reservationForm.Show();
        }


        #region setup listview


        public void setUpListViewsForRooms()
        {
            tableLabel.Text = roomButton.Text;

            ListViewItem roomDetails;
            listView.Clear();

            // Set up columns for the Room ListView
            listView.Columns.Insert(0, "RoomType", 240, HorizontalAlignment.Left);
            listView.Columns.Insert(1, "Price PerNight", 240, HorizontalAlignment.Left);

            foreach (Room room in rooms) // Assuming 'rooms' is a collection of Room objects
            {

                roomDetails = new ListViewItem();

                roomDetails.Text = room.RoomType; // RoomType as string
                roomDetails.SubItems.Add(room.Price.ToString("C")); // Price as currency

                listView.Items.Add(roomDetails);
            }

            listView.Refresh();
            listView.GridLines = true;
            listView.View = View.Details;
        }




        public void setUpListViewForCustomer()
        {
            tableLabel.Text = guestButton.Text;
            //EnableEntries(true);
            //ClearAll();
            // ShowAll(false, roleValue)
            ListViewItem customerDetails;
            listView.Clear();

            listView.Columns.Insert(0, "CustomerID", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(1, "FirstName", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(2, "LastName", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(3, "Email", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(4, "ContactNumber", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(5, "StreetAdress", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(6, "Town", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(7, "City", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(8, "PostalCode", 120, HorizontalAlignment.Left);



            foreach (Customer customer in customers)
            {
                customerDetails = new ListViewItem();
                customerDetails.Text = customer.CustomerID.ToString();
                customerDetails.SubItems.Add(customer.FirstName);
                customerDetails.SubItems.Add(customer.LastName);
                customerDetails.SubItems.Add(customer.Email);
                customerDetails.SubItems.Add(customer.ContactNumber);
                customerDetails.SubItems.Add(customer.StreetAddress);
                customerDetails.SubItems.Add(customer.Town);
                customerDetails.SubItems.Add(customer.City);
                customerDetails.SubItems.Add(customer.PostalCode);
                // Do the same for EmpID, Name and Phon
                listView.Items.Add(customerDetails);
            }

            listView.Refresh();
            listView.GridLines = true;
            listView.View = View.Details;
        }
        public void setUpListViewForBookings()
        {
            tableLabel.Text = bookingsButton.Text;

            ListViewItem reservationDetails;
            Customer customer;
            listView.Clear();

            listView.Columns.Insert(0, "ReservationId", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(1, "CustomerID", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(2, "Name", 120, HorizontalAlignment.Left);
            //listView.Columns.Insert(2, "ReservationDate", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(3, "RoomType", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(4, "checkInDate", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(5, "checkOutDate", 120, HorizontalAlignment.Left);
            listView.Columns.Insert(6, "Status", 120, HorizontalAlignment.Left);
            //listView.Columns.Insert(7, "TotalAmount", 120, HorizontalAlignment.Left);



            foreach (Reservation reservation in reservations)
            {
                reservationDetails = new ListViewItem();
                customer = customerController.Find(reservation.CustomerID);

                reservationDetails.Text = reservation.ReservationID.ToString();
                reservationDetails.SubItems.Add(reservation.CustomerID.ToString());
                reservationDetails.SubItems.Add(customer.FirstName + " " + customer.LastName);
                reservationDetails.SubItems.Add(reservation.RoomType.ToString());
                reservationDetails.SubItems.Add(reservation.CheckInDate.ToShortDateString());
                reservationDetails.SubItems.Add(reservation.CheckOutDate.ToShortDateString());
                reservationDetails.SubItems.Add(reservation.Status.ToString());
                //reservationDetails.SubItems.Add(reservation.TotalAmount.ToString());
                // Do the same for EmpID, Name and Phon
                listView.Items.Add(reservationDetails);
            }

            listView.Refresh();
            listView.GridLines = true;
            listView.View = View.Details;
        }
        #endregion


        private void SearchButton_Click(object sender, EventArgs e)
        {
            // Get the ReservationID from the searchTextBox
            string searchReservationID = searchTextBox.Text.Trim();

            

            // Clear the listView before displaying search results
            listView.Items.Clear();

            // Search for the reservation
            Reservation searchedReservation = reservationController.Find(searchReservationID);


            if (searchedReservation != null)
            {
                // Create a ListViewItem to display the reservation details
                ListViewItem reservationDetails = new ListViewItem();
                Customer customer = customerController.Find(searchedReservation.CustomerID);

                reservationDetails.Text = searchedReservation.ReservationID;
                reservationDetails.SubItems.Add(searchedReservation.CustomerID);
                reservationDetails.SubItems.Add(customer.FirstName + " " + customer.LastName);
                reservationDetails.SubItems.Add(searchedReservation.RoomType);
                reservationDetails.SubItems.Add(searchedReservation.CheckInDate.ToShortDateString());
                reservationDetails.SubItems.Add(searchedReservation.CheckOutDate.ToShortDateString());
                reservationDetails.SubItems.Add(searchedReservation.Status);

                // Add the reservation to the listView
                listView.Items.Add(reservationDetails);
                searchTextBox.Text = "";
            }
            else
            {
                // Show a message box if the ReservationID is not found
                MessageBox.Show("Reservation not found.");
            }

            // Refresh the listView to ensure it updates
            listView.Refresh();
        }

        private void HomePage_Load_2(object sender, EventArgs e)
        {
            if (currentEmployee != null)
            {
                label3.Text = currentEmployee.FirstName + " " + currentEmployee.LastName + ", " + currentEmployee.Position;
            } 
            viewState = ViewState.bookings;
            editButton.Visible = false;
            setUpListView();
        }

        private void bookingsButton_Click_2(object sender, EventArgs e)
        {
            viewState = ViewState.bookings; setUpListView();
        }

        private void roomButton_Click_2(object sender, EventArgs e)
        {
            viewState = ViewState.rooms; setUpListView();
        }

        private void guestButton_Click_2(object sender, EventArgs e)
        {
            viewState = ViewState.guests; setUpListView();
        }

        private void tableLabel_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click_1(object sender, EventArgs e)
        {
            switch (viewState)
            {
                case ViewState.guests:
                    break;
                case ViewState.bookings:
                    EditForm form = new EditForm(reservation, Customer, reservationController);
                    form.ShowDialog();
                    break;
                case ViewState.rooms:
                    break;
            }
             
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count > 0) // if you selected an item
            {
                switch (viewState)
                {
                    case ViewState.guests:
                        editButton.Text = "Change Guest Details";
                        editButton.Visible = true;
                        Customer = customerController.Find(listView.SelectedItems[0].Text);
                        break;
                    case ViewState.bookings:
                        editButton.Text = "Change Reservation";
                        editButton.Visible = true;
                        reservation = reservationController.Find(listView.SelectedItems[0].Text);
                        Customer = customerController.Find(reservation.CustomerID);
                        break;
                }
            }
        }

        private void signOutButton_Click(object sender, EventArgs e)
        {
            
            signInForm signInForm = new signInForm();
            signInForm.MdiParent = this.MdiParent;
            signInForm.WindowState = FormWindowState.Maximized;
            this.Hide();
            signInForm.Show();
            this.Close();
        }

        private void viewReportbutton_Click(object sender, EventArgs e)
        {
            OccupancyReportForm occupancyReportForm = new OccupancyReportForm(employeeID);
            occupancyReportForm.Show();

            this.Close();
        }

    }
}

