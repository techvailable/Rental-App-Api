using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IOrderService
    {

        Task <List<OrderDto>> Get();
        Task<ResponseDto> Add(OrderDto orderDto);
        Task<ResponseDto> Update(OrderDto orderDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<OrderDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
