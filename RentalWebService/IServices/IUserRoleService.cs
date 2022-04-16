using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IUserRoleService
    {

        Task <List<UserRoleDto>> Get();
        Task<ResponseDto> Add(UserRoleDto userRoleDto);
        Task<ResponseDto> Update(UserRoleDto userRoleDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<UserRoleDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
