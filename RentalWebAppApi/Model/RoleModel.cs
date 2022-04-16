using RentalWebService.DTOs;

namespace RentalWebAppApi.Models
{
    public class RoleModel
    {
        public  RoleDto RoleDto { get; set; }
        public List<RoleDto> RoleDtoList { get; set; }
        public ResponseDto ResponseDto { get; set; }
    }
}
