using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using Phumpla_Kamnandi.Application;

namespace Phumpla_Kamnandi.Data
{
    public class TransactionsDB : DB
    {
        #region Data Members
        private string table = "Transactions";
        private string sqlLocal = "SELECT * FROM Transactions";
        private Collection<Transaction> transactions;
        #endregion

        #region Property Methods
        public Collection<Transaction> AllTransactions
        {
            get { return transactions; }
        }
        #endregion

        #region Constructor
        public TransactionsDB() : base()
        {
            transactions = new Collection<Transaction>();
            FillDataSet(sqlLocal, table);
            Add2Collection();
        }
        #endregion

        #region Utility Methods
        private void Add2Collection()
        {
            DataRow myRow = null;
            Transaction aTransaction;

            foreach (DataRow currentRow in dsMain.Tables[table].Rows)
            {
                myRow = currentRow;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    aTransaction = new Transaction(
                        Convert.ToString(myRow["TransactionID"]).Trim(),
                        Convert.ToString(myRow["ReservationId"]).Trim(),
                        Convert.ToString(myRow["CustomerID"]).Trim(),
                        Convert.ToDateTime(myRow["TransactionDate"]),
                        Convert.ToDecimal(myRow["Amount"])
                    );

                    transactions.Add(aTransaction);
                }
            }
        }

        private void FillRow(DataRow row, Transaction aTransaction, DB.DBOperation operation)
        {
            if (operation == DBOperation.Add)
            {
                row["TransactionID"] = aTransaction.TransactionId;
            }
            row["ReservationID"] = aTransaction.ReservationId;
            row["CustomerID"] = aTransaction.CustomerId;
            row["Amount"] = aTransaction.Amount;
            row["TransactionDate"] = aTransaction.TransactionDate;
        }

        private int FindRow(Transaction aTransaction, string table)
        {
            int rowIndex = 0;
            DataRow myRow;
            int returnValue = -1;
            foreach (DataRow myRow_ in dsMain.Tables[table].Rows)
            {
                myRow = myRow_;
                if (myRow.RowState != DataRowState.Deleted)
                {
                    if (aTransaction.TransactionId == Convert.ToString(dsMain.Tables[table].Rows[rowIndex]["TransactionID"]))
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
        public void DataSetChange(Transaction aTransaction, DB.DBOperation operation)
        {
            DataRow aRow = null;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[table].NewRow();
                    FillRow(aRow, aTransaction, operation);
                    dsMain.Tables[table].Rows.Add(aRow);
                    break;
                case DB.DBOperation.Edit:
                    aRow = dsMain.Tables[table].Rows[FindRow(aTransaction, table)];
                    FillRow(aRow, aTransaction, operation);
                    break;
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        public bool UpdateDataSource(Transaction aTransaction)
        {
            bool success = true;
            Create_INSERT_Command(aTransaction);
            Create_UPDATE_Command(aTransaction);
            success = UpdateDataSource(sqlLocal, table);
            return success;
        }

        private void Build_INSERT_Parameters(Transaction aTransaction)
        {
            SqlParameter param = new SqlParameter("@TransactionID", SqlDbType.NChar, 5, "TransactionID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ReservationID", SqlDbType.NChar, 5, "ReservationID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Money, 0, "Amount");
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@TransactionDate", SqlDbType.DateTime, 0, "TransactionDate");
            daMain.InsertCommand.Parameters.Add(param);
        }

        private void Create_INSERT_Command(Transaction aTransaction)
        {
            daMain.InsertCommand = new SqlCommand(
                "INSERT INTO Transactions (TransactionID, ReservationID, CustomerID, Amount, TransactionDate) " +
                "VALUES (@TransactionID, @ReservationID, @CustomerID, @Amount, @TransactionDate)", cnMain);
            Build_INSERT_Parameters(aTransaction);
        }

        private void Build_UPDATE_Parameters(Transaction aTransaction)
        {
            SqlParameter param = new SqlParameter("@ReservationID", SqlDbType.NChar, 5, "ReservationID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@CustomerID", SqlDbType.NChar, 5, "CustomerID");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@Amount", SqlDbType.Money, 0, "Amount");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@TransactionDate", SqlDbType.DateTime, 0, "TransactionDate");
            param.SourceVersion = DataRowVersion.Current;
            daMain.UpdateCommand.Parameters.Add(param);

            param = new SqlParameter("@TransactionID", SqlDbType.NChar, 5, "TransactionID");
            param.SourceVersion = DataRowVersion.Original;
            daMain.UpdateCommand.Parameters.Add(param);
        }

        private void Create_UPDATE_Command(Transaction aTransaction)
        {
            daMain.UpdateCommand = new SqlCommand(
                "UPDATE Transactions SET ReservationID = @ReservationID, CustomerID = @CustomerID, " +
                "Amount = @Amount, TransactionDate = @TransactionDate WHERE TransactionID = @TransactionID", cnMain);
            Build_UPDATE_Parameters(aTransaction);
        }
        #endregion
    }
}
