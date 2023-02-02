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
                _log.Info($"Generated reference number for order {order.ReferenceNumber}.");
            }

            _log.Debug($"Loading customer {order.CustomerId} from database.");
            var customer = _database.GetCustomer(order.CustomerId);
            if(customer.IsBusiness && !string.IsNullOrEmpty(customer.Email))
            {
                try
                {
                    _log.Debug($"Sending email for customer {order.CustomerId}. Customer is a business customer and has email address set.");
                    MailService.SendEmail("New Order", $"Your order is successfully received.", customer.Email);
                } catch (Exception ex) { 
                    _log.Error($"Failed to send email for {order.CustomerId}.", ex);
                }
            }

            if(!customer.IsBusiness) {
                _log.Debug($"Customer {order.CustomerId} is not business customer. Skip the email sending.");
            }


            try
            {
                var result = _database.SaveOrder(order);
                _log.Debug($"The order {order.ReferenceNumber} saved succesfully.");
            } catch(Exception ex) { 
                _log.Debug($"Failed to save the order {order.ReferenceNumber}.");
            }            
        }
    }
}
