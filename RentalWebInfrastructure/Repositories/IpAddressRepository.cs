using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories;
using RentalWebInfrastructure.Repositories.Base;

namespace RentalWebInfrastructure.Repositories
{
    public class IpAddressRepository : Repository<IpAddress>, IIpAddressRepository
    {
        public IpAddressRepository(RentalWebContext context) :  base(context)
        {

        }

        public async Task Add(IpAddress ipAddress)
        {
            await InsertAsync(ipAddress);

        }
        public async Task DeleteRecord(IpAddress ipAddress)
        {
            Delete(ipAddress);
        }

        public async Task<IEnumerable<IpAddress>> GetList()
        {
            return (IList<IpAddress>)GetAsync();
        }

        public void UpdateRecord(IpAddress ipAddress)
        {
            Update(ipAddress);
        }
        //public int GetClientsCount()
        //{
        //    try
        //    {
        //        var x = Get();


        //        var clients = (IList<IpAddress>)Get();
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
