using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumpla_Kamnandi.Application
{
    public class Reservation
    {
        #region Data Members
        private string reservationID;
        private string customerID;
        private DateTime reservationDate;
        private string roomType;
        private DateTime checkInDate;
        private DateTime checkOutDate;
        private string status;
        private string NumofPeople;
        private decimal totalAmount;
        #endregion

        #region Constructor
        public Reservation(string reservationID, string customerID, DateTime reservationDate, string roomType, DateTime checkInDate, DateTime checkOutDate, string status, string NumofPeople, decimal totalAmount) { 
            this.reservationID = reservationID;
            this.customerID = customerID;
            this.reservationDate = reservationDate;
            this.roomType = roomType;
            this.checkInDate = checkInDate;
            this.checkOutDate = checkOutDate;
            this.status = status;
            this.NumofPeople = NumofPeople;
            this.TotalAmount = totalAmount;

        }
        #endregion

        #region Property Methods

        public string NumOfPeople {
            get { return NumofPeople; }
            set { NumofPeople = value;}
        }
        public string ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        public string CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public DateTime ReservationDate {
            get { return reservationDate; }
            set { reservationDate = value; }
        }

        public string RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }

        public DateTime CheckInDate
        {
            get { return checkInDate; }
            set { checkInDate = value; }
        }

        public DateTime CheckOutDate
        {
            get { return checkOutDate; }
            set { checkOutDate = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }
        #endregion
    }
}
