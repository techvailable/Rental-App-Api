using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<User>> GetList();
        Task Add(User user);
        void UpdateRecord(User user);
        Task DeleteRecord(User user);
    }
}
