using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class Order : Entity
    {
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public Int64 CartId { get; set; }
        public double Cost { get; set; }
        public double? Tax { get; set; }
        public double Total { get; set; }
        public string Currency { get; set; }
        public bool Status { get; set; }
        public virtual User User { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Shipping Shipping { get; set; }

    }
}
