using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IProductReviewService
    {

        Task <List<ProductReviewDto>> Get();
        Task<ResponseDto> Add(ProductReviewDto productReviewDto);
        //Task<ResponseDto> Update(ProductReviewDto productReviewDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<ProductReviewDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
