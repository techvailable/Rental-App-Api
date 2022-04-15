using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<Order>> GetList();
        Task Add(Order order);
        void UpdateRecord(Order order);
        Task DeleteRecord(Order order);
    }
}
