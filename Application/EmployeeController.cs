using Phumpla_Kamnandi.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumpla_Kamnandi.Application
{
    public class EmployeeController
    {
        #region Data Members
        private EmployeeDB employeeDB;
        private Collection<Employee> employees;
        #endregion

        #region Properties
        public Collection<Employee> AllEmployees
        {
            get { return employees; }
        }
        #endregion

        #region Constructor
        public EmployeeController()
        {
            // Instantiate the EmployeeDB object to communicate with the database
            employeeDB = new EmployeeDB();
            employees = employeeDB.AllEmployees;
        }
        #endregion

        #region Database Communication
        public void DataMaintenance(Employee anEmp, DB.DBOperation operation)
        {
            int index = 0;
            // Perform a given database operation to the dataset in memory
            employeeDB.DataSetChange(anEmp, operation);

            switch (operation)
            {
                case DB.DBOperation.Add:
                    employees.Add(anEmp);
                    break;

                case DB.DBOperation.Edit:
                    index = FindIndex(anEmp);
                    employees[index] = anEmp;
                    break;

                case DB.DBOperation.Delete:
                    index = FindIndex(anEmp);
                    employees.RemoveAt(index);
                    break;
            }
        }
        // Commit the changes to the database
        public bool FinalizeChanges(Employee employee)
        {
            return employeeDB.UpdateDataSource(employee);
        }
        #endregion

        #region Search Methods
        public Employee Find(string ID)
        {
            int index = 0;
            bool found = (employees[index].EmployeeID == ID);
            int count = employees.Count;

            while (!(found) && (index < count - 1))
            {
                index++;
                found = (employees[index].EmployeeID == ID);
            }
            return employees[index];
        }

        public int FindIndex(Employee anEmp)
        {
            int counter = 0;
            bool found = false;
            found = (anEmp.EmployeeID == employees[counter].EmployeeID);

            while (!(found) && (counter < employees.Count - 1))
            {
                counter++;
                found = (anEmp.EmployeeID == employees[counter].EmployeeID);
            }
            return found ? counter : -1;
        }
        #endregion
    }
}
