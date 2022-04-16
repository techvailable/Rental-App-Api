using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories;
using System.Data;

namespace RentalWebInfrastructure.Repositories
{
    public class ProcedureRepository : IProcedureRepository
    {
        private readonly RentalWebContext context;
        public ProcedureRepository(RentalWebContext context)
        {
            this.context = context;
        }

        public async Task<List<SpGetProductsByStore>> GetProductByBrand(long brandId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@branId", brandId);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_by_brand]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStore>> GetProductByBrandCategory(long categoryId, long brandId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@categoryId", categoryId);
                    queryParameters.Add("@branId", brandId);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_by_category_brand]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStore>> GetProductByCategory(long categoryId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@categoryId", categoryId);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_by_category]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStore>> GetProductByStore(Int64 storeId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@storeId", storeId);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_by_store]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStore>> GetProductByStoreCategory(long storeId, long categoryId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@storeId", storeId);
                    queryParameters.Add("@categoryId", categoryId);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_by_store_category]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStore>> GetProductByStoreSubBrandCategory(long storeId, long categoryId, long subCategoryId, long brandId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@storeId", storeId);
                    queryParameters.Add("@categoryId", categoryId);
                    queryParameters.Add("@subCategoryId", subCategoryId);
                    queryParameters.Add("@branId", brandId);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_by_store_sub_category_brand]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStore>> GetProductByStoreSUBCategory(long storeId, long categoryId, long subCategoryId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@storeId", storeId);
                    queryParameters.Add("@categoryId", categoryId);
                    queryParameters.Add("@subCategoryId", subCategoryId);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_by_store_sub_category]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStore>> GetProductBySubBrandCategory(long categoryId, long brandId, long subCategoryId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@categoryId", categoryId);
                    queryParameters.Add("@branId", brandId);
                    queryParameters.Add("@subCategoryId", subCategoryId);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_by_sub_category_brand]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public async Task<List<SpGetProductsByStore>> GetProductBySubCategory(long subCategoryId)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@subCategoryId", subCategoryId);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_by_sub_category]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }
        public async Task<List<SpGetProductsByStore>> GetProductBySearch(string filter)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(context.Database.GetDbConnection().ConnectionString))
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@filter", filter);

                    var result = await sqlConnection.QueryAsync<SpGetProductsByStore>("[dbo].[sp_product_search]", queryParameters, commandType: CommandType.StoredProcedure);
                    return result.AsList<SpGetProductsByStore>();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
