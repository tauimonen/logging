using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingAssignment.Models
{
    internal class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<(Product product, int Amount)> Products { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsPaid { get; set; }
        public string ReferenceNumber { get; set; }
    }
}
