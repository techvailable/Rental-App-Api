using RentalWebInfrastructure.Entities;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IProcedureRepository
    {
        Task<List<SpGetProductsByStore>> GetProductByStore(Int64 storeId);
        Task<List<SpGetProductsByStore>> GetProductBySubBrandCategory(Int64 categoryId, Int64 brandId, Int64 subCategoryId);
        Task<List<SpGetProductsByStore>> GetProductByBrandCategory(Int64 categoryId, Int64 brandId);
        Task<List<SpGetProductsByStore>> GetProductByBrand(Int64 brandId);
        Task<List<SpGetProductsByStore>> GetProductBySubCategory(Int64 subCategoryId);
        Task<List<SpGetProductsByStore>> GetProductByStoreSubBrandCategory(Int64 storeId, Int64 categoryId, Int64 subCategoryId, Int64 brandId);
        Task<List<SpGetProductsByStore>> GetProductByStoreCategory(Int64 storeId, Int64 categoryId);
        Task<List<SpGetProductsByStore>> GetProductByStoreSUBCategory(Int64 storeId, Int64 categoryId, Int64 subCategoryId);
        Task<List<SpGetProductsByStore>> GetProductByCategory(Int64 categoryId);
        Task<List<SpGetProductsByStore>> GetProductBySearch(string filter);
    }
}
