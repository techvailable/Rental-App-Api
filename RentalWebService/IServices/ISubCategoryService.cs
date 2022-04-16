using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface ISubCategoryService
    {

        Task <List<SubCategoryDto>> Get();
        Task<ResponseDto> Add(SubCategoryDto subCategoryDto);
        Task<ResponseDto> Update(SubCategoryDto subCategoryDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<SubCategoryDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
