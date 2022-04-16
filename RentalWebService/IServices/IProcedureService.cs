using RentalWebService.DTOs;

namespace RentalWebService.IServices
{
    public interface IProcedureService
    {
        Task<List<SpGetProductsByStoreDtos>> GetProductByStore(Int64 storeId);
        Task<List<SpGetProductsByStoreDtos>> GetProductBySubBrandCategory(Int64 categoryId, Int64 brandId, Int64 subCategoryId);
        Task<List<SpGetProductsByStoreDtos>> GetProductByBrandCategory(Int64 categoryId, Int64 brandId);
        Task<List<SpGetProductsByStoreDtos>> GetProductByBrand(Int64 brandId);
        Task<List<SpGetProductsByStoreDtos>> GetProductBySubCategory(Int64 subCategoryId);
        Task<List<SpGetProductsByStoreDtos>> GetProductByStoreSubBrandCategory(Int64 storeId, Int64 categoryId, Int64 subCategoryId, Int64 brandId);
        Task<List<SpGetProductsByStoreDtos>> GetProductByStoreCategory(Int64 storeId, Int64 categoryId);
        Task<List<SpGetProductsByStoreDtos>> GetProductByStoreSUBCategory(Int64 storeId, Int64 categoryId, Int64 subCategoryId);
        Task<List<SpGetProductsByStoreDtos>> GetProductByCategory(Int64 categoryId);
        Task<List<SpGetProductsByStoreDtos>> GetProductBySearch(string filter);
    }
}
