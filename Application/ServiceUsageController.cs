using System;
using System.Collections.ObjectModel;
using Phumpla_Kamnandi.Data;

namespace Phumpla_Kamnandi.Application
{
    public class ServiceUsageController
    {
        #region Data Members
        private ServiceUsageDB serviceUsageDB;
        private Collection<ServiceUsage> serviceUsages;
        #endregion

        #region Properties
        public Collection<ServiceUsage> AllServiceUsages
        {
            get { return serviceUsages; }
        }
        #endregion

        #region Constructor
        public ServiceUsageController()
        {
            // Instantiate the ServiceUsageDB object to communicate with the database
            serviceUsageDB = new ServiceUsageDB();
            serviceUsages = serviceUsageDB.AllServiceUsages;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(ServiceUsage aUsage, DB.DBOperation operation)
        {
            int index = 0;
            serviceUsageDB.DataSetChange(aUsage, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    serviceUsages.Add(aUsage);
                    break;

                case DB.DBOperation.Edit:
                    index = FindIndex(aUsage);
                    serviceUsages[index] = aUsage;
                    break;

                case DB.DBOperation.Delete:
                    index = FindIndex(aUsage);
                    serviceUsages.RemoveAt(index);
                    break;
            }
        }

        // Commit changes to the database
        public bool FinalizeChanges(ServiceUsage serviceUsage)
        {
            return serviceUsageDB.UpdateDataSource(serviceUsage);
        }
        #endregion

        #region Search Methods
        public ServiceUsage Find(string serviceUsageID)
        {
            int index = 0;
            bool found = (serviceUsages[index].ServiceUsageId == serviceUsageID);
            int count = serviceUsages.Count;

            while (!(found) && (index < count - 1))
            {
                index++;
                found = (serviceUsages[index].ServiceUsageId == serviceUsageID);
            }
            return serviceUsages[index];
        }

        public int FindIndex(ServiceUsage aUsage)
        {
            int counter = 0;
            bool found = false;
            found = (aUsage.ServiceUsageId == serviceUsages[counter].ServiceUsageId);

            while (!(found) && (counter < serviceUsages.Count - 1))
            {
                counter++;
                found = (aUsage.ServiceUsageId == serviceUsages[counter].ServiceUsageId);
            }
            return found ? counter : -1;
        }
        #endregion
    }
}
