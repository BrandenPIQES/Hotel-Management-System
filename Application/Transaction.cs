using System;

namespace Phumpla_Kamnandi.Application
{
    public class Transaction
    {
        #region Data Members
        private string transactionId;
        private string reservationId;
        private string customerId;
        private decimal amount;
        private DateTime transactionDate;
        #endregion

        #region Constructor
        public Transaction(string transactionID, string reservationID, string customerId, DateTime reservDate, decimal totalAmount) { 
            this.transactionId = transactionID;
            this.reservationId = reservationID;
            this.customerId = customerId;
            this.amount = totalAmount;
            this.transactionDate = reservDate;
        }
        #endregion

        #region Property Methods
        public string TransactionId
        {
            get { return transactionId; }
            set { transactionId = value; }
        }

        public string ReservationId
        {
            get { return reservationId; }
            set { reservationId = value; }
        }

        public string CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        }
        #endregion
    }
}
