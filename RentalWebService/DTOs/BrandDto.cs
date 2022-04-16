using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebService.DTOs
{
    public partial class BrandDto : Dto
    {
        
        public Int64 Id { get; set; }
        public Int64 CategoryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
