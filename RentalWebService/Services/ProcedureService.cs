using RentalWebInfrastructure.Infrastructure;
using RentalWebService.DTOs;
using RentalWebService.IServices;

namespace RentalWebService.Services
{
    public class ProcedureService : IProcedureService
    {
        private readonly IUnitOfWork unitOfWork;
        public ProcedureService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<SpGetProductsByStoreDtos>> GetProductByBrand(long brandId)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductByBrand(brandId);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<SpGetProductsByStoreDtos>> GetProductBySearch(string filter)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductBySearch(filter);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStoreDtos>> GetProductByBrandCategory(long categoryId, long brandId)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductByBrandCategory(categoryId, brandId);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStoreDtos>> GetProductByCategory(long categoryId)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductByCategory(categoryId);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStoreDtos>> GetProductByStore(Int64 storeId)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductByStore(storeId);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStoreDtos>> GetProductByStoreCategory(long storeId, long categoryId)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductByStoreCategory(storeId, categoryId);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStoreDtos>> GetProductByStoreSubBrandCategory(long storeId, long categoryId, long subCategoryId, long brandId)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductByStoreSubBrandCategory(storeId, categoryId, subCategoryId, brandId);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStoreDtos>> GetProductByStoreSUBCategory(long storeId, long categoryId, long subCategoryId)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductByStoreSUBCategory(storeId, categoryId, subCategoryId);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStoreDtos>> GetProductBySubBrandCategory(long categoryId, long brandId, long subCategoryId)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductBySubBrandCategory(categoryId, brandId, subCategoryId);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStoreDtos>> GetProductBySubCategory(long subCategoryId)
        {
            try
            {
                var products = await unitOfWork.ProcedureRepository.GetProductBySubCategory(subCategoryId);

                var list = Mapper.Mapping.Mapper.Map<List<SpGetProductsByStoreDtos>>(products);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
