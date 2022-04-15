using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class PhysicalAddressModel
    {
        public  PhysicalAddressDto PhysicalAddressDto { get; set; }
        public List<PhysicalAddressDto> PhysicalAddressDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
