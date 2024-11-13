using Phumpla_Kamnandi.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumpla_Kamnandi.Application
{
    public class CustomerController
    {
        #region Data Members
        private CustomersDB customerDB;
        private Collection<Customer> customers;
        #endregion

        #region Properties
        public Collection<Customer> AllCustomers
        {
            get { return customers; }
        }
        #endregion

        #region Constructor
        public CustomerController()
        {
            // Instantiate the CustomersDB object to communicate with the database
            customerDB = new CustomersDB();
            customers = customerDB.AllCustomers;
        }
        #endregion

        public bool CreateCustomer(string customerId, string firstName, string lastName, string email, string contactNumber, string streetAddress, string town, string city, string postalCode)
        {
            Customer newCustomer = new Customer(customerId, firstName, lastName, email, contactNumber, streetAddress, town, city, postalCode);

            //customerDB.DataSetChange(newCustomer, DB.DBOperation.Add);
            //customerDB.UpdateDataSource(newCustomer);
            DataMaintenance(newCustomer, DB.DBOperation.Add);
            FinalizeChanges(newCustomer);

            return true;
        }

        #region Database Communication
        public void DataMaintenance(Customer aCust, DB.DBOperation operation)
        {
            int index = 0;
            // Perform a given database operation to the dataset in memory
            customerDB.DataSetChange(aCust, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    customers.Add(aCust);
                    break;

                case DB.DBOperation.Edit:
                    index = FindIndex(aCust);
                    customers[index] = aCust;
                    break;

                case DB.DBOperation.Delete:
                    index = FindIndex(aCust);
                    customers.RemoveAt(index);
                    break;
            }
        }
        // Commit the changes to the database
        public bool FinalizeChanges(Customer customer)
        {
            return customerDB.UpdateDataSource(customer);
        }
        #endregion

        #region Search Methods
        public Customer Find(string ID)
        {
            int index = 0;
            bool found = (customers[index].CustomerID == ID);
            int count = customers.Count;

            while (!(found) && (index < count - 1))
            {
                index++;
                found = (customers[index].CustomerID == ID);
            }
            return customers[index];
        }

        public int FindIndex(Customer aCust)
        {
            int counter = 0;
            bool found = false;
            found = (aCust.CustomerID == customers[counter].CustomerID);

            while (!(found) && (counter < customers.Count - 1))
            {
                counter++;
                found = (aCust.CustomerID == customers[counter].CustomerID);
            }
            return found ? counter : -1;
        }
        #endregion
    }
}
