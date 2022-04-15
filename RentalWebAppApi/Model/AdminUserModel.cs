using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class AdminUserModel
    {
        public  AdminUserDto AdminUserDto { get; set; }
        public List<AdminUserDto> AdminUserDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
        public UserTokens UserTokens { get; set; }
    }
}
