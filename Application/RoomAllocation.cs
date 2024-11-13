using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumpla_Kamnandi.Application
{
    public class RoomAllocation
    {
        #region Data Members
        private string roomAllocationID;
        private string reservationID;
        private string roomNumber;
        private DateTime allocationDate;
        private DateTime CheckIn;
        private DateTime CheckOut;
        #endregion

        #region Properties
        public DateTime CheckInDate {
            get { return CheckIn; }
            set { CheckIn = value;}
        }

        public DateTime CheckOutDate
        {
            get { return CheckOut; }
            set { CheckOut = value; }
        }
        public string RoomAllocationID
        {
            get { return roomAllocationID; }
            set { roomAllocationID = value; }
        }

        public string ReservationID
        {
            get { return reservationID; }
            set { reservationID = value; }
        }

        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public DateTime AllocationDate
        {
            get { return allocationDate; }
            set { allocationDate = value; }
        }
        #endregion
    }

}
