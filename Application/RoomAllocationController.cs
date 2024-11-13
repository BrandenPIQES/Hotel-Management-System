using Phumpla_Kamnandi.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumpla_Kamnandi.Application
{

    public class RoomAllocationController
    {
        #region Data Members
        private RoomAllocationDB roomAllocationDB;
        private Collection<RoomAllocation> roomAllocations;
        #endregion

        #region Properties
        public Collection<RoomAllocation> AllRoomAllocations
        {
            get { return roomAllocations; }
        }
        #endregion

        #region Constructor
        public RoomAllocationController()
        {
            roomAllocationDB = new RoomAllocationDB();
            roomAllocations = roomAllocationDB.AllRoomAllocations;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(RoomAllocation roomAllocation, DB.DBOperation operation)
        {
            int index = 0;
            roomAllocationDB.DataSetChange(roomAllocation, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    roomAllocations.Add(roomAllocation);
                    break;

                case DB.DBOperation.Edit:
                    index = FindIndex(roomAllocation);
                    roomAllocations[index] = roomAllocation;
                    break;

                case DB.DBOperation.Delete:
                    index = FindIndex(roomAllocation);
                    roomAllocations.RemoveAt(index);
                    break;
            }
        }

        public bool FinalizeChanges(RoomAllocation roomAllocation)
        {
            return roomAllocationDB.UpdateDataSource(roomAllocation);
        }
        #endregion

        #region Search Methods
        public RoomAllocation Find(string roomAllocationID)
        {
            int index = 0;
            bool found = (roomAllocations[index].RoomAllocationID == roomAllocationID);
            int count = roomAllocations.Count;

            while (!(found) && (index < count - 1))
            {
                index++;
                found = (roomAllocations[index].RoomAllocationID == roomAllocationID);
            }
            return roomAllocations[index];
        }

        public int FindIndex(RoomAllocation roomAllocation)
        {
            int counter = 0;
            bool found = false;
            found = (roomAllocation.RoomAllocationID == roomAllocations[counter].RoomAllocationID);

            while (!(found) && (counter < roomAllocations.Count - 1))
            {
                counter++;
                found = (roomAllocation.RoomAllocationID == roomAllocations[counter].RoomAllocationID);
            }
            return found ? counter : -1;
        }
        #endregion

        // This method returns rooms that are allocated between the check-in and check-out dates
        public Collection<RoomAllocation> GetAllocatedRooms(DateTime checkInDate, DateTime checkOutDate)
        {
            Collection<RoomAllocation> allocatedRooms = new Collection<RoomAllocation>();

            foreach (var allocation in roomAllocations)
            {
                // Check if the allocation overlaps with the given date range
                if (allocation.CheckInDate <= checkOutDate && allocation.CheckOutDate >= checkInDate)
                {
                    allocatedRooms.Add(allocation);
                }
            }

            return allocatedRooms;
        }
    }
}
