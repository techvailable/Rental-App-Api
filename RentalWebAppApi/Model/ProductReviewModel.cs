using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class ProductReviewModel
    {
        public  ProductReviewDto ProductReviewDto { get; set; }
        public List<ProductReviewDto> ProductReviewDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
