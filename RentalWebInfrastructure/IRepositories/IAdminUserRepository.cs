using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IAdminUserRepository : IRepository<AdminUser>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<AdminUser>> GetList();
        Task Add(AdminUser adminUser);
        void UpdateRecord(AdminUser adminUser);
        Task DeleteRecord(AdminUser adminUser);
    }
}
