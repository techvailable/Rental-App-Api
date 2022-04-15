using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IShippingService
    {

        Task <List<ShippingDto>> Get();
        Task<ResponseDto> Add(ShippingDto shippingDto);
        //Task<ResponseDto> Update(ShippingDto shippingDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<ShippingDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
