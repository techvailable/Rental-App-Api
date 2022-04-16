using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class BrandModel
    {
        public  BrandDto BrandDto { get; set; }
        public List<BrandDto> BrandDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
