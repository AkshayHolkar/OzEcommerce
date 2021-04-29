using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Property { get; set; }
        public string StreetName { get; set; }
        public int Postcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public ApplicationUser User { get; set; }
    }
}
