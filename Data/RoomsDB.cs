using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phumpla_Kamnandi.Application;

namespace Phumpla_Kamnandi.Data
{
    public class RoomsDB:DB
    {
        #region Data Members
        private string table = "Rooms";
        private string sqlLocal = "SELECT * FROM Rooms";
        private Collection<Room> rooms;
        #endregion

        #region Property Methods
        public Collection<Room> AllRooms
        {
            get { return rooms; }
        }
        #endregion

        #region Constructor
        public RoomsDB() : base()
        {
            rooms = new Collection<Room>();
            FillDataSet(sqlLocal, table);
            Add2Collection();
        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }

        private void Add2Collection()
        {
            DataRow myRow = null;
            Room aRoom;

            foreach (DataRow currentRow in dsMain.Tables[table].Rows)
            {
                myRow = currentRow;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    aRoom = new Room();
                    aRoom.RoomNumber = Convert.ToString(myRow["RoomNumber"]).Trim();
                    aRoom.RoomType = Convert.ToString(myRow["RoomType"]).Trim();
                    aRoom.Available = Convert.ToBoolean(myRow["Available"]);
                    aRoom.Price = Convert.ToDecimal(myRow["Price"]);

                    rooms.Add(aRoom);
                }
            }
        }

        private void FillRow(DataRow row, Room aRoom)
        {
            // ITS A ROOM WE ONLY NEED TO UPDATE THE STATUS(AVAILABILIITY)
            //row["RoomNumber"] = aRoom.RoomNumber;
            //row["RoomType"] = aRoom.RoomType;
            row["Available"] = aRoom.Available;
            //row["Price"] = aRoom.Price;
        }

        private int FindRow(Room aRoom, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_ in dsMain.Tables[table].Rows)
            {
                myRow = myRow_;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (aRoom.RoomNumber == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["RoomNumber"]))
                    {
                        returnValue = rowIndex;
                        break;
                    }
                }
                rowIndex++;
            }
            return returnValue;
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Room aRoom)
        {
            DataRow aRow = null;
            aRow = dsMain.Tables[table].Rows[FindRow(aRoom, table)];
            FillRow(aRow, aRoom);
        }
        #endregion

        #region  Build Parameters, Create Commands & Update database
        public bool UpdateDataSource(Room aRoom)
        {
            bool success = true;
            Create_UPDATE_Command(aRoom);

            success = UpdateDataSource(sqlLocal, table);

            return success;
        }

        private void Build_UPDATE_Parameters(Room aRoom)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@Available", SqlDbType.Bit, 0, "Available");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@RoomNumber", SqlDbType.NChar, 5, "RoomNumber");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Create_UPDATE_Command(Room aRoom)
        {
            daMain.UpdateCommand = new SqlCommand(
                "UPDATE Rooms SET Available = @Available WHERE RoomNumber = @RoomNumber", cnMain);
            Build_UPDATE_Parameters(aRoom);
        }
        #endregion


    }
}
