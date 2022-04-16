using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebService.DTOs
{
    public partial class ShippingDto : Dto
    {

        public Int64 Id { get; set; }
        public Int64 OrderId { get; set; }
        public Int64 ShippingAddress { get; set; }
        public string ShippingMethod { get; set; }
        public string? Status { get; set; }
    }
}
