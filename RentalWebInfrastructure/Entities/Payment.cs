using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class Payment : Entity
    {
       
        
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public Int64 OrderId { get; set; }
        public string PaymentType { get; set; }
        public string Token { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public virtual User User { get; set; }
        public virtual Order Order { get; set; }

    }
}
