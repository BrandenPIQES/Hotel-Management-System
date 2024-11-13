using Phumpla_Kamnandi.Application;
using Phumpla_Kamnandi.Data;
using static Phumpla_Kamnandi.Data.DB;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using System;

public class CustomersDB : DB
{
    #region Data Members
    private string table = "Customers";
    private string sqlLocal = "SELECT * FROM Customers";
    private Collection<Customer> customers;
    #endregion

    #region Property Methods
    public Collection<Customer> AllCustomers
    {
        get { return customers; }
    }
    #endregion

    #region Constructor
    public CustomersDB() : base()
    {
        customers = new Collection<Customer>();
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
        Customer aCust;

        foreach (DataRow currentRow in dsMain.Tables[table].Rows)
        {
            myRow = currentRow;
            if (myRow.RowState != DataRowState.Deleted)
            {
                aCust = new Customer(
                    Convert.ToString(myRow["CustomerID"]).Trim(),
                    Convert.ToString(myRow["FirstName"]).Trim(),
                    Convert.ToString(myRow["LastName"]).Trim(),
                    Convert.ToString(myRow["Email"]).Trim(),
                    Convert.ToString(myRow["ContactNumber"]).Trim(),
                    Convert.ToString(myRow["StreetAddress"]).Trim(),
                    Convert.ToString(myRow["Town"]).Trim(),
                    Convert.ToString(myRow["City"]).Trim(),
                    Convert.ToString(myRow["PostalCode"]).Trim()
                );
                customers.Add(aCust);
            }
        }
    }


    private void FillRow(DataRow row, Customer aCust, DB.DBOperation operation)
    {

        if (operation == DBOperation.Add)
        {
            // THE CUSTOMERS OWN ID
            row["CustomerID"] = aCust.CustomerID;
        }

        row["FirstName"] = aCust.FirstName;
        row["LastName"] = aCust.LastName;
        row["Email"] = aCust.Email;
        row["ContactNumber"] = aCust.ContactNumber;
        row["StreetAddress"] = aCust.StreetAddress;
        row["Town"] = aCust.Town;
        row["City"] = aCust.City;
        row["PostalCode"] = aCust.PostalCode;
    }

    private int FindRow(Customer aCust, string table)
    {
        int rowIndex = 0;
        DataRow myRow;
        int returnValue = -1;
        foreach (DataRow myRow_ in dsMain.Tables[table].Rows)
        {
            myRow = myRow_;
            if (myRow.RowState != DataRowState.Deleted)
            {
                if (aCust.CustomerID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["CustomerID"]))
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
    public void DataSetChange(Customer aCust, DB.DBOperation operation)
    {
        DataRow aRow = null;
        switch (operation)
        {
            case DB.DBOperation.Add:
                aRow = dsMain.Tables[table].NewRow();
                FillRow(aRow, aCust, operation);
                dsMain.Tables[table].Rows.Add(aRow);
                break;
            case DB.DBOperation.Edit:
                aRow = dsMain.Tables[table].Rows[FindRow(aCust, table)];
                FillRow(aRow, aCust, operation);
                break;

                // CAN WE DELETE A CUSTOMER??
        }
    }
    #endregion

    #region Build Parameters, Create Commands & Update database

    public bool UpdateDataSource(Customer aCust)
    {
        bool success = true;
        Create_INSERT_Command(aCust);
        Create_UPDATE_Command(aCust);
        Create_DELETE_Command(aCust);

        // Associate the commands with daMain
        daMain.InsertCommand = Create_INSERT_Command(aCust);
        daMain.UpdateCommand = Create_UPDATE_Command(aCust);
        daMain.DeleteCommand = Create_DELETE_Command(aCust);

        success = UpdateDataSource(sqlLocal, table);

        return success;
    }

    private SqlCommand Create_INSERT_Command(Customer aCust)
    {
        SqlCommand cmd = new SqlCommand(
            "INSERT INTO Customers (CustomerID, FirstName, LastName, Email, ContactNumber, StreetAddress, Town, City, PostalCode) " +
            "VALUES (@CustomerID, @FirstName, @LastName, @Email,@ContactNumber, @StreetAddress, @Town, @City, @PostalCode)", cnMain);
        Build_INSERT_Parameters(cmd, aCust);
        return cmd;
    }

    private void Build_INSERT_Parameters(SqlCommand cmd, Customer aCust)
    {
        cmd.Parameters.Clear();

        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.NChar, 5, "CustomerID"));
        cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 100, "FirstName"));
        cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 100, "LastName"));
        cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 150, "Email"));
        cmd.Parameters.Add(new SqlParameter("@ContactNumber", SqlDbType.NVarChar, 15, "ContactNumber"));
        cmd.Parameters.Add(new SqlParameter("@StreetAddress", SqlDbType.NVarChar, 150, "StreetAddress"));
        cmd.Parameters.Add(new SqlParameter("@Town", SqlDbType.NVarChar, 100, "Town"));
        cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 100, "City"));
        cmd.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode"));
    }

    private SqlCommand Create_UPDATE_Command(Customer aCust)
    {
        SqlCommand cmd = new SqlCommand(
            "UPDATE Customers SET FirstName = @FirstName, LastName = @LastName, Email = @Email, ContactNumber = @ContactNumber, " +
            "StreetAddress = @StreetAddress, Town = @Town, City = @City, PostalCode = @PostalCode " +
            "WHERE CustomerID = @CustomerID", cnMain);
        Build_UPDATE_Parameters(cmd, aCust);
        return cmd;
    }

    private void Build_UPDATE_Parameters(SqlCommand cmd, Customer aCust)
    {
        cmd.Parameters.Clear();

        cmd.Parameters.Add(new SqlParameter("@FirstName", SqlDbType.NVarChar, 100, "FirstName") { SourceVersion = DataRowVersion.Current });
        cmd.Parameters.Add(new SqlParameter("@LastName", SqlDbType.NVarChar, 100, "LastName") { SourceVersion = DataRowVersion.Current });
        cmd.Parameters.Add(new SqlParameter("@ContactNumber", SqlDbType.NVarChar, 15, "ContactNumber") { SourceVersion = DataRowVersion.Current });
        cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 150, "Email") { SourceVersion = DataRowVersion.Current });
        cmd.Parameters.Add(new SqlParameter("@StreetAddress", SqlDbType.NVarChar, 255, "StreetAddress") { SourceVersion = DataRowVersion.Current });
        cmd.Parameters.Add(new SqlParameter("@Town", SqlDbType.NVarChar, 100, "Town") { SourceVersion = DataRowVersion.Current });
        cmd.Parameters.Add(new SqlParameter("@City", SqlDbType.NVarChar, 100, "City") { SourceVersion = DataRowVersion.Current });
        cmd.Parameters.Add(new SqlParameter("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode") { SourceVersion = DataRowVersion.Current });
        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.NChar, 5, "CustomerID") { SourceVersion = DataRowVersion.Original });
    }

    private SqlCommand Create_DELETE_Command(Customer aCust)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerID = @CustomerID", cnMain);
        Build_DELETE_Parameters(cmd, aCust);
        return cmd;
    }

    private void Build_DELETE_Parameters(SqlCommand cmd, Customer aCust)
    {
        cmd.Parameters.Clear();

        cmd.Parameters.Add(new SqlParameter("@CustomerID", SqlDbType.NVarChar, 10, "CustomerID") { SourceVersion = DataRowVersion.Original });
    }

    #endregion
}
