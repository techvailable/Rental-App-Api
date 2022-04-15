using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class DashboardModel
    {
        public List<CategoryDto> CategoryDtos { get; set; }
        public List<BrandDto> BrandDtos { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
