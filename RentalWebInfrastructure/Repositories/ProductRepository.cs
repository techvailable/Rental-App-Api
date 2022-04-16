using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories;
using RentalWebInfrastructure.Repositories.Base;

namespace RentalWebInfrastructure.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(RentalWebContext context) :  base(context)
        {

        }

        public async Task Add(Product product)
        {
            await InsertAsync(product);

        }
        public async Task DeleteRecord(Product product)
        {
            Delete(product);
        }

        public async Task<IEnumerable<Product>> GetList()
        {
            return (IList<Product>)GetAsync();
        }
        public async Task<IEnumerable<Product>> GetFeatured()
        {
            var featuredProduct = await GetAsync(x => x.Featured);
            return  featuredProduct;
        }

        public void UpdateRecord(Product product)
        {
            Update(product);
        }
        //public int GetClientsCount()
        //{
        //    try
        //    {
        //        var x = Get();


        //        var clients = (IList<Product>)Get();
        //        return clients.Count;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw;
        //    }
        //}
        //public DataTable GetClientsProcedure(int clientID)
        //{
        //    try
        //    {
        //        SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();

        //        SqlCommand command = connection.CreateCommand();
        //        connection.Open();
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.CommandText = "[dbo].[ClientProcedure]";
        //        command.Parameters.Add("@clientID", System.Data.SqlDbType.Int).Value = clientID;
        //        SqlDataReader reader = command.ExecuteReader();

        //        DataTable dTable = new DataTable();
        //        dTable.Load(reader);

        //        connection.Close();

        //        return dTable;
        //    }
        //    catch (Exception exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
