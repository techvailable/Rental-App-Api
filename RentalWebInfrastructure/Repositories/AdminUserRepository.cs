using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories;
using RentalWebInfrastructure.Repositories.Base;

namespace RentalWebInfrastructure.Repositories
{
    public class AdminUserRepository : Repository<AdminUser>, IAdminUserRepository
    {
        public AdminUserRepository(RentalWebContext context) :  base(context)
        {

        }

        public async Task Add(AdminUser adminUser)
        {
            await InsertAsync(adminUser);

        }
        public async Task DeleteRecord(AdminUser adminUser)
        {
            Delete(adminUser);
        }

        public async Task<IEnumerable<AdminUser>> GetList()
        {
            return (IList<AdminUser>)GetAsync();
        }

        public void UpdateRecord(AdminUser adminUser)
        {
            Update(adminUser);
        }
        //public int GetClientsCount()
        //{
        //    try
        //    {
        //        var x = Get();


        //        var clients = (IList<AdminUser>)Get();
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
