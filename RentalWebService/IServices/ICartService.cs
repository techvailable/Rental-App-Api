using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface ICartService
    {

        Task <List<CartDto>> Get();
        Task<ResponseDto> Add(CartDto cartDto);
        Task<ResponseDto> Update(CartDto cartDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<CartDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
