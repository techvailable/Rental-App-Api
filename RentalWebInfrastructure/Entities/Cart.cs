using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class Cart : Entity
    {

        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
        public Int64 Id { get; set; }
        public decimal Total { get; set; }
        public bool Status { get; set; }
        public virtual Order Orders { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
