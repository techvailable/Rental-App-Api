using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class Shipping : Entity
    {

        public Int64 Id { get; set; }
        public Int64 OrderId { get; set; }
        public Int64 ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }
        public string? Status { get; set; }
        public virtual Order Order { get; set; }
        public virtual PhysicalAddress PhysicalAddress { get; set; }
    }
}
