using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IProductService
    {

        Task <List<ProductDto>> Get();
        Task <List<ProductDto>> GetFeatured();
        Task<ResponseDto> Add(ProductDto productDto);
        Task<ResponseDto> Update(ProductDto productDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<ProductDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
