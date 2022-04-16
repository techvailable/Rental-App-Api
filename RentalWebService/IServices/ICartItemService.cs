using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface ICartItemService
    {

        Task <List<CartItemDto>> Get();
        Task<ResponseDto> Add(CartItemDto cartItemDto);
        Task<ResponseDto> Update(CartItemDto cartItemDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<CartItemDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
