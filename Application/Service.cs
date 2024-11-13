using System;

namespace Phumpla_Kamnandi.Application
{
    public class Service
    {
        #region Data Members
        private int serviceId;
        private string serviceName;
        private decimal serviceCost;
        #endregion

        #region Property Methods
        public int ServiceId
        {
            get { return serviceId; }
            set { serviceId = value; }
        }

        public string ServiceName
        {
            get { return serviceName; }
            set { serviceName = value; }
        }

        public decimal ServiceCost
        {
            get { return serviceCost; }
            set { serviceCost = value; }
        }
        #endregion
    }
}
