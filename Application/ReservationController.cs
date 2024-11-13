using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phumpla_Kamnandi.Data;

namespace Phumpla_Kamnandi.Application
{
    public class ReservationController
    {
        #region Data Members
        private ReservationsDB reservationDB;
        private Collection<Reservation> reservations;
        private Reservation reservation;
        #endregion

        #region Properties
        public Collection<Reservation> AllReservations
        {
            get { return reservations; }
        }
        #endregion

        #region Constructor
        public ReservationController()
        {
            // Instantiate the ReservationsDB object to communicate with the database
            reservationDB = new ReservationsDB();
            reservations = reservationDB.AllReservations;
        }
        #endregion

        // Create a reservation and save it in the database
        public Reservation CreateReservation(string reservationID, string customerId, string roomType, DateTime reservDate, DateTime checkInDate, DateTime checkOutDate, string numOfPeople, decimal totalAmount)
        {
            
            reservation = new Reservation(
                    reservationID, 
                    customerId, 
                    reservDate,
                    roomType,
                    checkInDate, 
                    checkOutDate, 
                    "Pending",
                    numOfPeople, 
                    totalAmount
            );

            // Add the reservation to the database (through the ReservationsDB class)S
           DataMaintenance(reservation, DB.DBOperation.Add);

            // Make sure to finalize changes after adding to the database
            if (!FinalizeChanges(reservation))
            {
                // Handle failure (optional logging or throwing an exception)
                MessageBox.Show("fail to create reservation", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;    
            }
            return reservation;
        }

        // Confirm the reservation
        public bool ConfirmReservation(string reservationId)
        {
            bool success = false;
            // Find the reservation
            Reservation reservation = Find(reservationId);
            if (reservation != null)
            {
                // Change the status to "Confirmed"
                reservation.Status = "Confirmed";
                // Update the reservation in the database
                DataMaintenance(reservation, DB.DBOperation.Edit);
                FinalizeChanges(reservation);
                success = true;
            }
            return success;
        }
        public bool ConfirmReservation(Reservation reservation)
        {
            bool success = false;
                // Change the status to "Confirmed"
                reservation.Status = "Confirmed";
                // Update the reservation in the database
                DataMaintenance(reservation, DB.DBOperation.Edit);
                FinalizeChanges(reservation);
                success = true;
            return success;
        }

        #region Database Communication
        public void DataMaintenance(Reservation aRes, DB.DBOperation operation)
        {
            int index = 0;
            

            switch (operation)
            {
                case DB.DBOperation.Add:
                    reservations.Add(aRes);
                    break;

                case DB.DBOperation.Edit:
                    index = FindIndex(aRes);
                    reservations[index] = aRes;
                    break;

                case DB.DBOperation.Delete:
                    index = FindIndex(aRes);
                    reservations.RemoveAt(index);
                    break;
            }
            reservationDB.DataSetChange(aRes, operation);
        }

        // Commit changes to the database
        public bool FinalizeChanges(Reservation reservation)
        {
            return reservationDB.UpdateDataSource(reservation);
        }
        #endregion

        #region Search Methods
        public Reservation Find(string reservationID)
        {
            int index = 0;
            bool found = (  reservations[index].ReservationID.Trim()   ).Equals(  reservationID.Trim()  );
            int count = reservations.Count;

            while ((found==false) && (index < count - 1))
            {
                index++;
                found = (reservations[index].ReservationID == reservationID);
                if( (index == count - 1) && !found ) { return null; }
            }
            return reservations[index];
        }


        public int FindIndex(Reservation aRes)
        {
            int counter = 0;
            bool found = false;
            found = (aRes.ReservationID.Trim() == reservations[counter].ReservationID.Trim());

            while (!(found) && (counter < reservations.Count - 1))
            {
                counter++;
                found = (aRes.ReservationID == reservations[counter].ReservationID);
            }
            return found ? counter : -1;
        }
        #endregion
    }
}
