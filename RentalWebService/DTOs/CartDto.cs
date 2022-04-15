using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebService.DTOs
{
    public partial class CartDto : Dto
    {

        
        public Int64 Id { get; set; }
        public double Total { get; set; }
        public bool Status { get; set; }
    }
}
