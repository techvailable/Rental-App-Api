using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<Cart>> GetList();
        Task Add(Cart cart);
        void UpdateRecord(Cart cart);
        Task DeleteRecord(Cart cart);
    }
}
