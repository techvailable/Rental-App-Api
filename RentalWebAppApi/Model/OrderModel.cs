using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class OrderModel
    {
        public  OrderDto OrderDto { get; set; }
        public List<OrderDto> OrderDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
