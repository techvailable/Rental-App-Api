using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IShippingRepository : IRepository<Shipping>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<Shipping>> GetList();
        Task Add(Shipping shipping);
        void UpdateRecord(Shipping shipping);
        Task DeleteRecord(Shipping shipping);
    }
}
