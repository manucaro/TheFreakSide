using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheFreakSide.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public double TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string PhoneNumber { get; set; }

    }
}
