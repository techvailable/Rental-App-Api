using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebService.DTOs
{
    public partial class CartItemDto : Dto
    {

        
        public Int64 Id { get; set; }
        public Int64 CartId { get; set; }
        public Int64 ProductId { get; set; }
        public int Quantity { get; set; }
        public double? Discount { get; set; }
        public double Total { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
