using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories;
using RentalWebInfrastructure.Repositories.Base;

namespace RentalWebInfrastructure.Repositories
{
    public class ProductImagesRepository : Repository<ProductImages>, IProductImagesRepository
    {
        public ProductImagesRepository(RentalWebContext context) :  base(context)
        {

        }

        public async Task Add(ProductImages productImages)
        {
            await InsertAsync(productImages);

        }
        public async Task DeleteRecord(ProductImages productImages)
        {
            Delete(productImages);
        }

        public async Task<IEnumerable<ProductImages>> GetList()
        {
            return (IList<ProductImages>)GetAsync();
        }

        public void UpdateRecord(ProductImages productImages)
        {
            Update(productImages);
        }
        //public int GetClientsCount()
        //{
        //    try
        //    {
        //        var x = Get();


        //        var clients = (IList<ProductImages>)Get();
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
