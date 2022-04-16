using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.Infrastructure;
using RentalWebInfrastructure.IRepositories;
using RentalWebInfrastructure.Repositories.Base;

namespace RentalWebInfrastructure.Repositories
{
    public class PhysicalAddressRepository : Repository<PhysicalAddress>, IPhysicalAddressRepository
    {
        public PhysicalAddressRepository(RentalWebContext context) :  base(context)
        {

        }

        public async Task Add(PhysicalAddress physicalAddress)
        {
            await InsertAsync(physicalAddress);

        }
        public async Task DeleteRecord(PhysicalAddress physicalAddress)
        {
            Delete(physicalAddress);
        }

        public async Task<IEnumerable<PhysicalAddress>> GetList()
        {
            return (IList<PhysicalAddress>)GetAsync();
        }

        public void UpdateRecord(PhysicalAddress physicalAddress)
        {
            Update(physicalAddress);
        }
        //public int GetClientsCount()
        //{
        //    try
        //    {
        //        var x = Get();


        //        var clients = (IList<PhysicalAddress>)Get();
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
