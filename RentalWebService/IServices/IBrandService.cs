using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IBrandService
    {

        Task <List<BrandDto>> Get();
        Task<ResponseDto> Add(BrandDto brandDto);
        Task<ResponseDto> Update(BrandDto brandDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<BrandDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
