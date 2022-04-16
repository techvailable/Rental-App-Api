using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IUserService
    {

        Task <List<UserDto>> Get();
        Task<ResponseDto> Add(UserDto userDto);
        Task<ResponseDto> Update(UserDto userDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<UserDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
