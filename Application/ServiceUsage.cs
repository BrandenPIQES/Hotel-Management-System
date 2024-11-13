using System;

namespace Phumpla_Kamnandi.Application
{
    public class ServiceUsage
    {
        #region Data Members
        private string serviceUsageId;
        private string reservationId;
        private int serviceId;
        private int quantity;
        private DateTime usageDate;
        private decimal totalCost;
        #endregion

        #region Property Methods
        public string ServiceUsageId
        {
            get { return serviceUsageId; }
            set { serviceUsageId = value; }
        }

        public string ReservationId
        {
            get { return reservationId; }
            set { reservationId = value; }
        }

        public int ServiceId
        {
            get { return serviceId; }
            set { serviceId = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public DateTime UsageDate
        {
            get { return usageDate; }
            set { usageDate = value; }
        }

        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }
        #endregion
    }
}
