using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class UserRoleModel
    {
        public  UserRoleDto UserRoleDto { get; set; }
        public List<UserRoleDto> UserRoleDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
