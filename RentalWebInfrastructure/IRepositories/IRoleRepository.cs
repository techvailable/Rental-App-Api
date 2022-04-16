using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<Role>> GetList();
        Task Add(Role role);
        void UpdateRecord(Role role);
        Task DeleteRecord(Role role);
    }
}
