using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IIpAddressRepository : IRepository<IpAddress>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<IpAddress>> GetList();
        Task Add(IpAddress ipAddress);
        void UpdateRecord(IpAddress ipAddress);
        Task DeleteRecord(IpAddress ipAddress);
    }
}
