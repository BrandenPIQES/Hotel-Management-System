using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phumpla_Kamnandi.Application
{
    public class Customer
    {
        #region Data Members
        private string CustID;
        private string FName;
        private string LName;
        private string email;
        private string contactNumber;
        private string StreetAddr;
        private string town;
        private string city;
        private string postalCode;
        #endregion

        #region Constructor
        public Customer(string customerID, string firstName, string lastName, string email, string contactNumber, string streetAddress, string town, string city, string postalCode)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ContactNumber = contactNumber;
            StreetAddress = streetAddress;
            Town = town;
            City = city;
            PostalCode = postalCode;
        }
        #endregion

        #region Property Methods
        public string CustomerID {
            get { return CustID; }
            set { CustID = value; }
        }
        public string FirstName
        {
            get { return FName; }
            set { FName = value; }
        }
        public string LastName
        {
            get { return LName; }
            set { LName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string ContactNumber 
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
        public string StreetAddress
        {
            get { return StreetAddr; }
            set { StreetAddr = value; }
        }
        public string Town
        {
            get { return town; }
            set { town = value; }
        }
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }
        #endregion


    }
}
