using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class CategoryModel
    {
        public  CategoryDto CategoryDto { get; set; }
        public List<CategoryDto> CategoryDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
