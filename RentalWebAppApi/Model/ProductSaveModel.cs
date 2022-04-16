using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class ProductSaveModel
    {
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
        public string? Status { get; set; }
        public bool Featured { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
