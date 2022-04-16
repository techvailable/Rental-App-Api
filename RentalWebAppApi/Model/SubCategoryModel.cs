using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class SubCategoryModel
    {
        public  SubCategoryDto SubCategoryDto { get; set; }
        public List<SubCategoryDto> SubCategoryDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
