using System;
using System.Collections.Generic;
using System.Text;

namespace RentalWebService.DTOs
{
    public class Dto
    {
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool Active { get; set; }
    }
}
