using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<Payment>> GetList();
        Task Add(Payment payment);
        void UpdateRecord(Payment payment);
        Task DeleteRecord(Payment payment);
    }
}
