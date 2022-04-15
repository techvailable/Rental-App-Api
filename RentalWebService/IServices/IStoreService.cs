using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IStoreService
    {

        Task <List<StoreDto>> Get();
        Task<ResponseDto> Add(StoreDto storeDto);
        Task<ResponseDto> Update(StoreDto storeDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<StoreDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
