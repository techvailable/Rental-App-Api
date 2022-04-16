using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class StoreModel
    {
        public  StoreDto StoreDto { get; set; }
        public List<StoreDto> StoreDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
