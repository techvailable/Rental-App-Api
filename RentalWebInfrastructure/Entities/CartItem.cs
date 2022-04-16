using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class CartItem : Entity
    {

        
        public Int64 Id { get; set; }
        public Int64 CartId { get; set; }
        public Int64 ProductId { get; set; }
        public int Quantity { get; set; }
        public double? Discount { get; set; }
        public double Total { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
