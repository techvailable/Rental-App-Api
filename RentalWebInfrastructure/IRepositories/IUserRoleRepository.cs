using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<UserRole>> GetList();
        Task Add(UserRole userRole);
        void UpdateRecord(UserRole userRole);
        Task DeleteRecord(UserRole userRole);
    }
}
