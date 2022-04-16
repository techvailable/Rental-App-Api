using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebService.DTOs
{
    public partial class ProductDto : Dto
    {
        public Int64 Id { get; set; }
        public Int64 CategoryId { get; set; }
        public Int64 BrandId { get; set; }
        public Int64 SubCategoryId { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public string? Specifications { get; set; }
        public string? ProductIncludes { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public bool Featured { get; set; }
        public string? Types { get; set; }
        public string? Tags { get; set; }

    }
}
