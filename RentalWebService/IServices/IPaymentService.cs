using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IPaymentService
    {

        Task <List<PaymentDto>> Get();
        Task<ResponseDto> Add(PaymentDto paymentDto);
        //Task<ResponseDto> Update(PaymentDto paymentDto);
        Task<ResponseDto> DeleteById(Int64 Id);
        Task<PaymentDto> GetById(Int64 Id);
        //IEnumerable<ClientDto> GetClients();
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
    }
}
