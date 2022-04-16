using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IRoleService
    {

        Task <List<RoleDto>> Get();
        Task<ResponseDto> Add(RoleDto roleDto);
        Task<ResponseDto> Update(RoleDto roleDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<RoleDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
