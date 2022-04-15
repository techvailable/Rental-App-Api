using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class CartModel
    {
        public  CartDto CartDto { get; set; }
        public List<CartDto> CartDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
