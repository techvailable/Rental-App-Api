using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Entities
{
    public partial class SpGetProductsByStore
    {
       
        public Int64 ProductId { get; set; }
        public string ProductName { get; set; }
        public Int64 BrandId { get; set; }
        public Int64 CategoryId { get; set; }
        public Int64 SubCategoryId { get; set; }
        public string SKU { get; set; }
        public string Notes { get; set; }
        public string Specifications { get; set; }
        public string ProductIncludes { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Featured { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
        public Int64 StoreId { get; set; }
    }
}
