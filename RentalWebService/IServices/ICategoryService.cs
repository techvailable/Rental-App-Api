using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface ICategoryService
    {

        Task <List<CategoryDto>> Get();
        Task<ResponseDto> Add(CategoryDto categoryDto);
        Task<ResponseDto> Update(CategoryDto categoryDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<CategoryDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
