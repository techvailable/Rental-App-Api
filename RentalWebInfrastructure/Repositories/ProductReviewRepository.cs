using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories;
using RentalWebInfrastructure.Repositories.Base;

namespace RentalWebInfrastructure.Repositories
{
    public class ProductReviewRepository : Repository<ProductReview>, IProductReviewRepository
    {
        public ProductReviewRepository(RentalWebContext context) :  base(context)
        {

        }

        public async Task Add(ProductReview productReview)
        {
            await InsertAsync(productReview);

        }
        public async Task DeleteRecord(ProductReview productReview)
        {
            Delete(productReview);
        }

        public async Task<IEnumerable<ProductReview>> GetList()
        {
            return (IList<ProductReview>)GetAsync();
        }

        public void UpdateRecord(ProductReview productReview)
        {
            Update(productReview);
        }
        //public int GetClientsCount()
        //{
        //    try
        //    {
        //        var x = Get();


        //        var clients = (IList<ProductReview>)Get();
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
