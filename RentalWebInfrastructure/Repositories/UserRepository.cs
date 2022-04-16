using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories;
using RentalWebInfrastructure.Repositories.Base;

namespace RentalWebInfrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RentalWebContext context) :  base(context)
        {

        }

        public async Task Add(User user)
        {
            await InsertAsync(user);

        }
        public async Task DeleteRecord(User user)
        {
            Delete(user);
        }

        public async Task<IEnumerable<User>> GetList()
        {
            return (IList<User>)GetAsync();
        }

        public void UpdateRecord(User user)
        {
            Update(user);
        }
        //public int GetClientsCount()
        //{
        //    try
        //    {
        //        var x = Get();


        //        var clients = (IList<User>)Get();
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
