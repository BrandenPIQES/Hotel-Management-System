using System;
using System.Collections.ObjectModel;
using Phumpla_Kamnandi.Data;

namespace Phumpla_Kamnandi.Application
{
    public class ServiceController
    {
        #region Data Members
        private ServicesDB servicesDB;
        private Collection<Service> services;
        #endregion

        #region Properties
        public Collection<Service> AllServices
        {
            get { return services; }
        }
        #endregion

        #region Constructor
        public ServiceController()
        {
            // Instantiate the ServicesDB object to communicate with the database
            servicesDB = new ServicesDB();
            services = servicesDB.AllServices;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Service aService, DB.DBOperation operation)
        {
            int index = 0;
            servicesDB.DataSetChange(aService, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    services.Add(aService);
                    break;

                case DB.DBOperation.Edit:
                    index = FindIndex(aService);
                    services[index] = aService;
                    break;

                case DB.DBOperation.Delete:
                    index = FindIndex(aService);
                    services.RemoveAt(index);
                    break;
            }
        }

        // Commit changes to the database
        public bool FinalizeChanges(Service service)
        {
            return servicesDB.UpdateDataSource(service);
        }
        #endregion

        #region Search Methods
        public Service Find(string serviceID)
        {
            int index = 0;
            bool found = (services[index].ServiceId.ToString() == serviceID);
            int count = services.Count;

            while (!(found) && (index < count - 1))
            {
                index++;
                found = (services[index].ServiceId.ToString() == serviceID);
            }
            return services[index];
        }

        public int FindIndex(Service aService)
        {
            int counter = 0;
            bool found = false;
            found = (aService.ServiceId == services[counter].ServiceId);

            while (!(found) && (counter < services.Count - 1))
            {
                counter++;
                found = (aService.ServiceId == services[counter].ServiceId);
            }
            return found ? counter : -1;
        }
        #endregion
    }
}
