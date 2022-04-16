using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<Category>> GetList();
        Task Add(Category category);
        void UpdateRecord(Category category);
        Task DeleteRecord(Category category);
    }
}
