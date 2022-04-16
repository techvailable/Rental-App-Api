using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class CartItemModel
    {
        public  CartItemDto CartItemDto { get; set; }
        public List<CartItemDto> CartItemDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
