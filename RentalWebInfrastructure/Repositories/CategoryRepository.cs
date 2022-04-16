using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories;
using RentalWebInfrastructure.Repositories.Base;

namespace RentalWebInfrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(RentalWebContext context) :  base(context)
        {

        }

        public async Task Add(Category category)
        {
            await InsertAsync(category);

        }
        public async Task DeleteRecord(Category category)
        {
            Delete(category);
        }

        public async Task<IEnumerable<Category>> GetList()
        {
            return (IList<Category>)GetAsync();
        }

        public void UpdateRecord(Category category)
        {
            Update(category);
        }
        //public int GetClientsCount()
        //{
        //    try
        //    {
        //        var x = Get();


        //        var clients = (IList<Category>)Get();
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
