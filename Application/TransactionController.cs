using System;
using System.Collections.ObjectModel;
using Phumpla_Kamnandi.Data;

namespace Phumpla_Kamnandi.Application
{
    public class TransactionController
    {
        #region Data Members
        private TransactionsDB transactionDB;
        private Collection<Transaction> transactions;
        private Transaction transaction;
        #endregion

        #region Properties
        public Collection<Transaction> AllTransactions
        {
            get { return transactions; }
        }
        #endregion

        #region Constructor
        public TransactionController()
        {
            // Instantiate the TransactionsDB object to communicate with the database
            transactionDB = new TransactionsDB();
            transactions = transactionDB.AllTransactions;
        }
        #endregion


        public bool CreateTransaction(string transactionID ,string reservationID, string customerId, decimal totalAmount, DateTime reservDate)
        {
            bool success = true;
            transaction = new Transaction(
                    transactionID,
                    reservationID,
                    customerId,
                    reservDate,
                    totalAmount
            );

            DataMaintenance(transaction, DB.DBOperation.Add);
            FinalizeChanges(transaction);

            return success;
        }

        #region Database Communication
        public void DataMaintenance(Transaction aTransaction, DB.DBOperation operation)
        {
            int index = 0;
            transactionDB.DataSetChange(aTransaction, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    transactions.Add(aTransaction);
                    break;

                case DB.DBOperation.Edit:
                    index = FindIndex(aTransaction);
                    transactions[index] = aTransaction;
                    break;

                case DB.DBOperation.Delete:
                    index = FindIndex(aTransaction);
                    transactions.RemoveAt(index);
                    break;
            }
        }

        // Commit changes to the database
        public bool FinalizeChanges(Transaction transaction)
        {
            return transactionDB.UpdateDataSource(transaction);
        }
        #endregion

        #region Search Methods
        public Transaction Find(string transactionID)
        {
            int index = 0;
            bool found = (transactions[index].TransactionId == transactionID);
            int count = transactions.Count;

            while (!(found) && (index < count - 1))
            {
                index++;
                found = (transactions[index].TransactionId == transactionID);
            }
            return transactions[index];
        }

        public int FindIndex(Transaction aTransaction)
        {
            int counter = 0;
            bool found = false;
            found = (aTransaction.TransactionId == transactions[counter].TransactionId);

            while (!(found) && (counter < transactions.Count - 1))
            {
                counter++;
                found = (aTransaction.TransactionId == transactions[counter].TransactionId);
            }
            return found ? counter : -1;
        }
        #endregion
    }
}
