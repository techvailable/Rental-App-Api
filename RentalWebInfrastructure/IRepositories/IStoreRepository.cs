using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IStoreRepository : IRepository<Store>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<Store>> GetList();
        Task Add(Store store);
        void UpdateRecord(Store store);
        Task DeleteRecord(Store store);
    }
}
