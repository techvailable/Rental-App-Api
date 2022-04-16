using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IPhysicalAddressService
    {

        Task <List<PhysicalAddressDto>> Get();
        Task<ResponseDto> Add(PhysicalAddressDto physicalAddressDto);
        //Task<ResponseDto> Update(PhysicalAddressDto physicalAddressDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<PhysicalAddressDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
