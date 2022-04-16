using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebService.DTOs
{
    public partial class ProductImagesDto : Dto
    {

        public Int64 Id { get; set; }
        public Int64 ProductId { get; set; }
        public string? Title { get; set; }
        public string? Tags { get; set; }
        public bool Default { get; set; }
    }
}
