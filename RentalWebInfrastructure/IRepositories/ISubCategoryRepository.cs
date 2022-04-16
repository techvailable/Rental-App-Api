using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<SubCategory>> GetList();
        Task Add(SubCategory subCategory);
        void UpdateRecord(SubCategory subCategory);
        Task DeleteRecord(SubCategory subCategory);
    }
}
