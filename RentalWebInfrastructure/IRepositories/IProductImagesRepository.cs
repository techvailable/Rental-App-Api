using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IProductImagesRepository : IRepository<ProductImages>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<ProductImages>> GetList();
        Task Add(ProductImages productImages);
        void UpdateRecord(ProductImages productImages);
        Task DeleteRecord(ProductImages productImages);
    }
}
