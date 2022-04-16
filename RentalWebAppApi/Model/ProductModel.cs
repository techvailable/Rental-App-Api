using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class ProductModel
    {
        public  ProductDto ProductDto { get; set; }
        public List<ProductDto> ProductDtoList { get; set; }
        public List<SpGetProductsByStoreDtos> SpGetProductsByStoreDtos { get; set; }
        public ResponseDto ResponseDto { get; set; }
        public string ImagePath { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
