using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<Product>> GetList();
        Task<IEnumerable<Product>> GetFeatured();
        Task Add(Product product);
        void UpdateRecord(Product product);
        Task DeleteRecord(Product product);
    }
}
