using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class PaymentModel
    {
        public  PaymentDto PaymentDto { get; set; }
        public List<PaymentDto> PaymentDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
