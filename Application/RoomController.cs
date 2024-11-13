using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phumpla_Kamnandi.Data;

namespace Phumpla_Kamnandi.Application
{
    public class RoomController
    {
        #region Data Members
        private RoomsDB roomDB;
        private RoomAllocationController roomAllocationController;
        private Collection<Room> rooms;
        #endregion

        #region Properties
        public Collection<Room> AllRooms
        {
            get { return rooms; }
        }
        #endregion

        #region Constructor
        public RoomController()
        {
            // Instantiate the RoomsDB object to communicate with the database
            roomDB = new RoomsDB();
            rooms = roomDB.AllRooms;
            roomAllocationController = new RoomAllocationController();
        }
        #endregion

        #region Database Communication
        // Update room availability only
        public void DataMaintanance(Room aRoom)
        {
            int index = FindIndex(aRoom);
            rooms[index].Available = aRoom.Available;
            roomDB.DataSetChange(aRoom);
        }

        // Commit changes to the database
        public bool FinalizeChanges(Room room)
        {
            return roomDB.UpdateDataSource(room);
        }
        #endregion

        #region Search Methods
        public Room Find(string roomNumber)
        {
            int index = 0;
            bool found = (rooms[index].RoomNumber == roomNumber);
            int count = rooms.Count;

            while (!(found) && (index < count - 1))
            {
                index++;
                found = (rooms[index].RoomNumber == roomNumber);
            }
            return rooms[index];
        }
        public int FindIndex(Room aRoom)
        {
            int counter = 0;
            bool found = false;
            found = (aRoom.RoomNumber == rooms[counter].RoomNumber);

            while (!(found) && (counter < rooms.Count - 1))
            {
                counter++;
                found = (aRoom.RoomNumber == rooms[counter].RoomNumber);
            }
            return found ? counter : -1;
        }
        #endregion

        public Collection<Room> GetAvailableRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            // Step 1: Get all allocated rooms for the given date range from RoomAllocationController
            var allocatedRooms = roomAllocationController.GetAllocatedRooms(checkInDate, checkOutDate);

            // Step 2: Filter out the allocated rooms from the complete rooms collection
            Collection<Room> availableRooms = new Collection<Room>();

            foreach (var room in rooms)
            {
                bool isAllocated = allocatedRooms.Any(a => a.RoomNumber == room.RoomNumber);
                if (!isAllocated)
                {
                    availableRooms.Add(room); // Only add rooms that are not allocated
                }
            }

            return availableRooms; // Return available rooms for the given date range
        }
    }
}
