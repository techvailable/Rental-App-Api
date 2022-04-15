using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IProductReviewRepository : IRepository<ProductReview>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<ProductReview>> GetList();
        Task Add(ProductReview productReview);
        void UpdateRecord(ProductReview productReview);
        Task DeleteRecord(ProductReview productReview);
    }
}
