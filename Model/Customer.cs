using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        private int id;
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public int Id { get; set; }
        public string LastName { get; set; }

        public Customer(int id, string emailAddress, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            FullName = firstName + " " + lastName;
        }
        public Customer(){}

        public string ToString()
        {
            return $"{FullName} ({EmailAddress})";
        }
    }
}
