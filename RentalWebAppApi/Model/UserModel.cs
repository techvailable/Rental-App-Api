using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class UserModel
    {
        public  UserDto UserDto { get; set; }
        public List<UserDto> UserDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
