using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumpla_Kamnandi.Application
{
    public class Room
    {
        #region Data Members
        private string roomNumber;
        private string roomType;
        private bool available;
        private decimal price;
        #endregion

        #region Property Methods
        public string RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }

        public string RoomType
        {
            get { return roomType; }
            set { roomType = value; }
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion
    }
}
