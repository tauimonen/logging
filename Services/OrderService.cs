using log4net;
using LoggingAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAssignment.Services
{
    internal class OrderService
    {
        // Use this _log class to write neccessary log messages.
        private readonly ILog _log;
        private readonly DatabaseService _database;

        public OrderService(ILog log, DatabaseService database)
        {
            _log = log;
            _database = database;
        }

        public void ProcessOrder(Order order)
        {
            if(order is null)
            {
                throw new ArgumentNullException("order");
            }

            if(string.IsNullOrEmpty(order.ReferenceNumber))
            {
                order.ReferenceNumber = ReferenceGenerator.GenerateReferenceNumber();
            }

            var customer = _database.GetCustomer(order.CustomerId);
            if(customer.IsBusiness && !string.IsNullOrEmpty(customer.Email))
            {
                try
                {
                    MailService.SendEmail("New Order", $"Your order is successfully received.", customer.Email);
                } catch (Exception ex) { }
            }

            try
            {
                var result = _database.SaveOrder(order);
            } catch(Exception ex) { }            
        }
    }
}
