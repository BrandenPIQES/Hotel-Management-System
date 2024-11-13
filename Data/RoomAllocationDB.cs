using Phumpla_Kamnandi.Application;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumpla_Kamnandi.Data
{
    public class RoomAllocationDB : DB
    {
        #region Data Members
        private string table = "RoomAllocations";
        private string sqlLocal = "SELECT * FROM RoomAllocations";
        private Collection<RoomAllocation> roomAllocations;
        #endregion

        #region Property Methods
        public Collection<RoomAllocation> AllRoomAllocations
        {
            get { return roomAllocations; }
        }
        #endregion

        #region Constructor
        public RoomAllocationDB() : base()
        {
            roomAllocations = new Collection<RoomAllocation>();
            FillDataSet(sqlLocal, table);
            Add2Collection();
        }
        #endregion

        #region Utility Methods
        private void Add2Collection()
        {
            DataRow myRow;
            RoomAllocation roomAllocation;

            foreach (DataRow currentRow in dsMain.Tables[table].Rows)
            {
                myRow = currentRow;

                if (myRow.RowState != DataRowState.Deleted)
                {
                    roomAllocation = new RoomAllocation();
                    roomAllocation.RoomAllocationID = Convert.ToString(myRow["RoomAllocationID"]).Trim();
                    roomAllocation.ReservationID = Convert.ToString(myRow["ReservationId"]).Trim();
                    roomAllocation.RoomNumber = Convert.ToString(myRow["RoomNumber"]).Trim();
                    roomAllocation.AllocationDate = Convert.ToDateTime(myRow["AllocationDate"]);
                    roomAllocation.CheckInDate = Convert.ToDateTime(myRow["CheckInDate"]);
                    roomAllocation.CheckOutDate = Convert.ToDateTime(myRow["CheckOutDate"]);

                    roomAllocations.Add(roomAllocation);
                }
            }
        }

        private void FillRow(DataRow row, RoomAllocation roomAllocation, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                row["RoomAllocationID"] = roomAllocation.RoomAllocationID;
            }

            row["ReservationId"] = roomAllocation.ReservationID;
            row["RoomNumber"] = roomAllocation.RoomNumber;
            row["AllocationDate"] = roomAllocation.AllocationDate;
            row["CheckInDate"] = roomAllocation.CheckInDate;
            row["CheckOutDate"] = roomAllocation.CheckOutDate;
        }

        private int FindRow(RoomAllocation roomAllocation, string table)
        {
            int rowIndex = 0;
            foreach (DataRow myRow in dsMain.Tables[table].Rows)
            {
                if (myRow.RowState != DataRowState.Deleted && Convert.ToString(myRow["RoomAllocationID"]) == roomAllocation.RoomAllocationID)
                {
                    return rowIndex;
                }
                rowIndex++;
            }
            return -1;
        }
        #endregion

        #region CRUD Operations
        public void DataSetChange(RoomAllocation roomAllocation, DB.DBOperation operation)
        {
            DataRow aRow = null;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[table].NewRow();
                    FillRow(aRow, roomAllocation, operation);
                    dsMain.Tables[table].Rows.Add(aRow);
                    break;

                case DB.DBOperation.Edit:
                    aRow = dsMain.Tables[table].Rows[FindRow(roomAllocation, table)];
                    FillRow(aRow, roomAllocation, operation);
                    break;

                case DB.DBOperation.Delete:
                    dsMain.Tables[table].Rows[FindRow(roomAllocation, table)].Delete();
                    break;
            }
        }

        public bool UpdateDataSource(RoomAllocation roomAllocation)
        {
            Create_INSERT_Command(roomAllocation);
            Create_UPDATE_Command(roomAllocation);
            Create_DELETE_Command(roomAllocation);

            return UpdateDataSource(sqlLocal, table);
        }
        #endregion

        #region Build Parameters & Commands
        private void Build_INSERT_Parameters(RoomAllocation roomAllocation)
        {
            SqlParameter param = new SqlParameter("@RoomAllocationID", SqlDbType.NChar, 5, "RoomAllocationID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ReservationId", SqlDbType.NChar, 5, "ReservationId");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomNumber", SqlDbType.NChar, 5, "RoomNumber");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@AllocationDate", SqlDbType.Date, 0, "AllocationDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckInDate", SqlDbType.Date, 0, "CheckInDate");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckOutDate", SqlDbType.Date, 0, "CheckOutDate");
            daMain.InsertCommand.Parameters.Add(param);
        }


        private void Create_INSERT_Command(RoomAllocation roomAllocation)
        {
            daMain.InsertCommand = new SqlCommand(
                "INSERT INTO RoomAllocations (RoomAllocationID, ReservationId, RoomNumber, AllocationDate, CheckInDate, CheckOutDate) VALUES (@RoomAllocationID, @ReservationId, @RoomNumber, @AllocationDate, @CheckInDate, @CheckOutDate)",
                cnMain);
            Build_INSERT_Parameters(roomAllocation);
        }

        private void Build_UPDATE_Parameters(RoomAllocation roomAllocation)
        {

            SqlParameter param = new SqlParameter("@RoomAllocationID", SqlDbType.NChar, 5, "RoomAllocationID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ReservationId", SqlDbType.NChar, 5, "ReservationId");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomNumber", SqlDbType.NChar, 5, "RoomNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@AllocationDate", SqlDbType.Date, 0, "AllocationDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckInDate", SqlDbType.NChar, 5, "CheckInDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CheckOutDate", SqlDbType.NChar, 5, "CheckOutDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);
        }


        private void Create_UPDATE_Command(RoomAllocation roomAllocation)
        {
            daMain.UpdateCommand = new SqlCommand(
                "UPDATE RoomAllocations SET ReservationId = @ReservationId, RoomNumber = @RoomNumber, AllocationDate = @AllocationDate, CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate WHERE RoomAllocationID = @RoomAllocationID",
                cnMain);
            Build_UPDATE_Parameters(roomAllocation);
        }

        private void Build_DELETE_Parameters(RoomAllocation roomAllocation)
        {
            SqlParameter param = new SqlParameter("@RoomAllocationID", SqlDbType.NChar, 5, "RoomAllocationID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private void Create_DELETE_Command(RoomAllocation roomAllocation)
        {
            daMain.DeleteCommand = new SqlCommand("DELETE FROM RoomAllocations WHERE RoomAllocationID = @RoomAllocationID", cnMain);
            Build_DELETE_Parameters(roomAllocation);
        }
        #endregion

    }
}
