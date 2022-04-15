using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IAdminUserService
    {

        Task <List<AdminUserDto>> Get();
        Task <List<AdminUserDto>> GetByName(string name);
        Task<ResponseDto> Add(AdminUserDto adminUserDto);
        Task<ResponseDto> Update(AdminUserDto adminUserDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<AdminUserDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
