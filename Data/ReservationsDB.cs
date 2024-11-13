using Phumpla_Kamnandi.Application;
using Phumpla_Kamnandi.Data;
using static Phumpla_Kamnandi.Data.DB;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System;

public class ReservationsDB : DB
{
    #region Data Members
    private string table = "Reservations";
    private string sqlLocal = "SELECT * FROM Reservations";
    private Collection<Reservation> reservations;
    #endregion

    #region Property methods
    public Collection<Reservation> AllReservations
    {
        get { return reservations; }
    }
    #endregion

    #region Constructor
    public ReservationsDB() : base()
    {
        reservations = new Collection<Reservation>();
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
        Reservation aRes;

        foreach (DataRow currentRow in dsMain.Tables[table].Rows)
        {
            myRow = currentRow;
            if (myRow.RowState != DataRowState.Deleted)
            {
                aRes = new Reservation(
                    Convert.ToString(myRow["ReservationID"]).Trim(),
                    Convert.ToString(myRow["CustomerID"]).Trim(),
                    Convert.ToDateTime(myRow["ReservationDate"]),
                    Convert.ToString(myRow["RoomType"]).Trim(),
                    Convert.ToDateTime(myRow["CheckInDate"]),
                    Convert.ToDateTime(myRow["CheckOutDate"]),
                    Convert.ToString(myRow["Status"]).Trim(),
                    Convert.ToString(myRow["NumOfPeople"]).Trim(),
                    Convert.ToDecimal(myRow["TotalAmount"])
                );

                reservations.Add(aRes);
            }
        }
    }

    private void FillRow(DataRow row, Reservation aRes, DB.DBOperation operation)
    {
        if (operation == DBOperation.Add)
        {
            row["ReservationID"] = aRes.ReservationID;
        }

        row["CustomerID"] = aRes.CustomerID;
        row["RoomType"] = aRes.RoomType;
        row["ReservationDate"] = aRes.ReservationDate;
        row["CheckInDate"] = aRes.CheckInDate;
        row["CheckOutDate"] = aRes.CheckOutDate;
        row["Status"] = aRes.Status;
        row["NumOfPeople"] = aRes.NumOfPeople;
        row["TotalAmount"] = aRes.TotalAmount;
    }

    private int FindRow(Reservation aRes, string table)
    {
        int rowIndex = 0;
        DataRow myRow;
        int returnValue = -1;
        foreach (DataRow myRow_ in dsMain.Tables[table].Rows)
        {
            myRow = myRow_;
            if (myRow.RowState != DataRowState.Deleted)
            {
                if (aRes.ReservationID.Trim() == (Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["ReservationID"])).Trim())
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
    public void DataSetChange(Reservation aRes, DB.DBOperation operation)
    {
        DataRow aRow = null;
        switch (operation)
        {
            case DB.DBOperation.Add:
                aRow = dsMain.Tables[table].NewRow();
                FillRow(aRow, aRes, operation);
                dsMain.Tables[table].Rows.Add(aRow);
                break;
            case DB.DBOperation.Edit:
                aRow = dsMain.Tables[table].Rows[FindRow(aRes, table)];
                FillRow(aRow, aRes, operation);
                break;
        }
    }
    #endregion

    #region Build Parameters, Create Commands & Update database

    public bool UpdateDataSource(Reservation aRes)
    {
        bool success = true;

        // Associate commands with daMain
        daMain.InsertCommand = Create_INSERT_Command(aRes);
        daMain.UpdateCommand = Create_UPDATE_Command(aRes);
        daMain.DeleteCommand = Create_DELETE_Command(aRes);

        // This should actually push changes to the database
        try
        {
            success = daMain.Update(dsMain, table) > 0; // Check if rows are affected
        }
        catch (Exception ex)
        {
            // Log or handle exception
            success = false;
            Console.WriteLine("Database update failed: " + ex.Message);
        }

        return success;
    }


    private SqlCommand Create_INSERT_Command(Reservation aRes)
    {
        SqlCommand cmd = new SqlCommand(
        "INSERT INTO Reservations (ReservationID, CustomerID, ReservationDate, RoomType, CheckInDate, CheckOutDate, Status, NumOfPeople, TotalAmount) " +
        "VALUES (@ReservationID, @CustomerID, @ReservationDate, @RoomType, @CheckInDate, @CheckOutDate, @Status, @NumOfPeople, @TotalAmount)", cnMain);

        Build_INSERT_Parameters(cmd, aRes);
        return cmd;
    }

    private void Build_INSERT_Parameters(SqlCommand cmd, Reservation aRes)
    {
        cmd.Parameters.Clear();

        cmd.Parameters.AddRange(new SqlParameter[]
        {
            new SqlParameter("@ReservationID", SqlDbType.NChar, 5, "ReservationID"),
            new SqlParameter("@CustomerID", SqlDbType.NChar, 5, "CustomerID"),
            new SqlParameter("@ReservationDate", SqlDbType.DateTime, 0, "ReservationDate"),
            new SqlParameter("@RoomType", SqlDbType.NVarChar, 50, "RoomType"),
            new SqlParameter("@CheckInDate", SqlDbType.DateTime, 0, "CheckInDate"),
            new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 0, "CheckOutDate"),
            new SqlParameter("@Status", SqlDbType.NVarChar, 50, "Status"),
            new SqlParameter("@NumOfPeople", SqlDbType.NVarChar, 10, "NumOfPeople"),
            new SqlParameter("@TotalAmount", SqlDbType.Money, 0, "TotalAmount")
        });
    }

    private SqlCommand Create_UPDATE_Command(Reservation aRes)
    {
        SqlCommand cmd = new SqlCommand(
        "UPDATE Reservations SET CustomerID = @CustomerID, ReservationDate = @ReservationDate, RoomType = @RoomType, CheckInDate = @CheckInDate, " +
        "CheckOutDate = @CheckOutDate, Status = @Status, NumOfPeople = @NumOfPeople, TotalAmount = @TotalAmount " +
        "WHERE ReservationID = @ReservationID", cnMain);

        Build_UPDATE_Parameters(cmd, aRes);
        return cmd;
    }

    private void Build_UPDATE_Parameters(SqlCommand cmd, Reservation aRes)
    {
        cmd.Parameters.Clear();

        cmd.Parameters.AddRange(new SqlParameter[]
        {
            new SqlParameter("@CustomerID", SqlDbType.NChar, 5, "CustomerID") { SourceVersion = DataRowVersion.Current },
            new SqlParameter("@ReservationDate", SqlDbType.DateTime, 0, "ReservationDate") { SourceVersion = DataRowVersion.Current },
            new SqlParameter("@RoomType", SqlDbType.NVarChar, 50, "RoomType") { SourceVersion = DataRowVersion.Current },
            new SqlParameter("@CheckInDate", SqlDbType.DateTime, 0, "CheckInDate") { SourceVersion = DataRowVersion.Current },
            new SqlParameter("@CheckOutDate", SqlDbType.DateTime, 0, "CheckOutDate") { SourceVersion = DataRowVersion.Current },
            new SqlParameter("@Status", SqlDbType.NVarChar, 50, "Status") { SourceVersion = DataRowVersion.Current },
            new SqlParameter("@NumOfPeople", SqlDbType.NVarChar, 10, "NumOfPeople") { SourceVersion = DataRowVersion.Current },
            new SqlParameter("@TotalAmount", SqlDbType.Money, 0, "TotalAmount") { SourceVersion = DataRowVersion.Current },
            new SqlParameter("@ReservationID", SqlDbType.NChar, 5, "ReservationID") { SourceVersion = DataRowVersion.Original }
        });
    }

    private SqlCommand Create_DELETE_Command(Reservation aRes)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM Reservations WHERE ReservationID = @ReservationID", cnMain);

        Build_DELETE_Parameters(cmd, aRes);
        return cmd;
    }

    private void Build_DELETE_Parameters(SqlCommand cmd, Reservation aRes)
    {
        cmd.Parameters.Clear();

        cmd.Parameters.Add(new SqlParameter("@ReservationID", SqlDbType.NChar, 5, "ReservationID") { SourceVersion = DataRowVersion.Original });
    }

    #endregion
}
