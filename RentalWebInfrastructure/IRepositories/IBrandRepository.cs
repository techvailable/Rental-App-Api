using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<Brand>> GetList();
        Task Add(Brand brand);
        void UpdateRecord(Brand brand);
        Task DeleteRecord(Brand brand);
    }
}
