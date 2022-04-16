using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<CartItem>> GetList();
        Task Add(CartItem cartItem);
        void UpdateRecord(CartItem cartItem);
        Task DeleteRecord(CartItem cartItem);
    }
}
