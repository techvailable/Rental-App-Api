using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IIpAddressService
    {

        Task <List<IpAddressDto>> Get();
        Task<ResponseDto> Add(IpAddressDto ipAddressDto);
        Task<ResponseDto> Update(IpAddressDto ipAddressDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<IpAddressDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
