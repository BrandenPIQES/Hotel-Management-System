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
    public class EmployeeDB:DB
    {
        #region Data Members
        private string table = "Employees";
        private string sqlLocal = "SELECT * FROM Employees";
        private Collection<Employee> employees;
        #endregion

        #region Property Methods
        public Collection<Employee> AllEmployees
        {
            get { return employees; }
        }
        #endregion

        #region Constructor
        public EmployeeDB() : base()
        {
            employees = new Collection<Employee>();
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
            Employee anEmp;

            foreach (DataRow currentRow in dsMain.Tables[table].Rows)
            {
                myRow = currentRow;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    anEmp = new Employee();
                    anEmp.EmployeeID = Convert.ToString(myRow["EmployeeID"]).Trim();
                    anEmp.FirstName = Convert.ToString(myRow["FirstName"]).Trim();
                    anEmp.LastName = Convert.ToString(myRow["LastName"]).Trim();
                    anEmp.Position = Convert.ToString(myRow["Position"]).Trim();
                    anEmp.Email = Convert.ToString(myRow["Email"]).Trim();
                    anEmp.ContactNumber = Convert.ToString(myRow["ContactNumber"]).Trim();
                    anEmp.PasswordHash = Convert.ToString(myRow["PasswordHash"]).Trim();

                    employees.Add(anEmp);
                }
            }
        }

        private void FillRow(DataRow row, Employee anEmp, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                row["EmployeeID"] = anEmp.EmployeeID;
            }

            row["FirstName"] = anEmp.FirstName;
            row["LastName"] = anEmp.LastName;
            row["Position"] = anEmp.Position;
            row["Email"] = anEmp.Email;
            row["ContactNumber"] = anEmp.ContactNumber;
            row["PasswordHash"] = anEmp.PasswordHash;
        }

        private int FindRow(Employee anEmp, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_ in dsMain.Tables[table].Rows)
            {
                myRow = myRow_;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (anEmp.EmployeeID == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["EmployeeID"]))
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
        public void DataSetChange(Employee anEmp, DB.DBOperation operation)
        {
            DataRow aRow = null;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[table].NewRow();
                    FillRow(aRow, anEmp, operation);
                    dsMain.Tables[table].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    aRow = dsMain.Tables[table].Rows[FindRow(anEmp, table)];
                    FillRow(aRow, anEmp, operation);
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database

        public bool UpdateDataSource(Employee anEmp)
        {
            bool success = true;
            Create_INSERT_Command(anEmp);
            Create_UPDATE_Command(anEmp);
            Create_DELETE_Command(anEmp);

            success = UpdateDataSource(sqlLocal, table);

            return success;
        }

        private void Build_INSERT_Parameters(Employee anEmp)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@EmployeeID", SqlDbType.NChar, 5, "EmployeeID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 100, "FirstName");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@LastName", SqlDbType.NVarChar, 100, "LastName");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Position", SqlDbType.NVarChar, 50, "Position");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.NVarChar, 150, "Email");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ContactNumber", SqlDbType.NVarChar, 15, "ContactNumber");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 255, "PasswordHash");
            daMain.InsertCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(Employee anEmp)
        {
            daMain.InsertCommand = new SqlCommand(
                "INSERT INTO Employees (EmployeeID, FirstName, LastName, Position, Email, ContactNumber, PasswordHash) " +
                "VALUES (@EmployeeID, @FirstName, @LastName, @Position, @Email, @ContactNumber, @PasswordHash)", cnMain);
            Build_INSERT_Parameters(anEmp);
        }

        private void Build_UPDATE_Parameters(Employee anEmp)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@FirstName", SqlDbType.NVarChar, 100, "FirstName");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@LastName", SqlDbType.NVarChar, 100, "LastName");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Position", SqlDbType.NVarChar, 50, "Position");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Email", SqlDbType.NVarChar, 150, "Email");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@ContactNumber", SqlDbType.NVarChar, 15, "ContactNumber");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 255, "PasswordHash");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@EmployeeID", SqlDbType.NChar, 5, "EmployeeID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Create_UPDATE_Command(Employee anEmp)
        {
            daMain.UpdateCommand = new SqlCommand(
                "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Position = @Position, " +
                "Email = @Email, ContactNumber = @ContactNumber, PasswordHash = @PasswordHash " +
                "WHERE EmployeeID = @EmployeeID", cnMain);
            Build_UPDATE_Parameters(anEmp);
        }

        private void Build_DELETE_Parameters(Employee anEmp)
        {
            SqlParameter param = default(SqlParameter);

            param = new SqlParameter("@EmployeeID", SqlDbType.NChar, 5, "EmployeeID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.DeleteCommand.Parameters.Add(param);
        }

        private void Create_DELETE_Command(Employee anEmp)
        {
            daMain.DeleteCommand = new SqlCommand("DELETE FROM Employees WHERE EmployeeID = @EmployeeID", cnMain);
            Build_DELETE_Parameters(anEmp);
        }

        #endregion
    }
}
