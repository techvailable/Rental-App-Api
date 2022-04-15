using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class User : Entity
    {
        public User()
        {
            PhysicalAddress = new HashSet<PhysicalAddress>();
            Payments = new HashSet<Payment>();
            IpAddresses = new HashSet<IpAddress>();
            Orders = new HashSet<Order>();
            ProductReviews = new HashSet<ProductReview>();
        }
        
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailVerify { get; set; }

        public virtual ICollection<PhysicalAddress> PhysicalAddress { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<IpAddress>  IpAddresses { get; set; }
        public virtual ICollection<Order>  Orders { get; set; }
        public virtual ICollection<ProductReview>  ProductReviews { get; set; }
    }
}
