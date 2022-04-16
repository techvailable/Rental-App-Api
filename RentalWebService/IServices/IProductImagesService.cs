using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IProductImagesService
    {

        Task <List<ProductImagesDto>> Get();
        Task<ResponseDto> Add(ProductImagesDto productImagesDto);
        //Task<ResponseDto> Update(ProductImagesDto productImagesDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<ProductImagesDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
