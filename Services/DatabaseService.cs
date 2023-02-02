using LoggingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAssignment.Services
{
    internal class DatabaseService
    {
        public bool SaveOrder(Order order)
        {
            // This is just sample which would store order into database.
            // Returns true if database save success, otherwise false.
            return true;
        }

        internal Customer GetCustomer(int customerId)
        {
            // This is just sample which would return customer from database.
            return new Customer();
        }
    }
}
