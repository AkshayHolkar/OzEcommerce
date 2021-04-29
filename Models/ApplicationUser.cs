using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public DateTimeOffset CreateDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<ComboRecommendation> ComboRecommendation { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<Vendor> Vendor { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Review> Review { get; set; }
    }
}
