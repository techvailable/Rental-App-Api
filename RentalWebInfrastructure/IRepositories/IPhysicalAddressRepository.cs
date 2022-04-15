using RentalWebInfrastructure.Entities;
using RentalWebInfrastructure.IRepositories.Base;

namespace RentalWebInfrastructure.IRepositories
{
    public interface IPhysicalAddressRepository : IRepository<PhysicalAddress>
    {
        //int GetClientsCount();
        //DataTable GetClientsProcedure(int clientID);
        Task<IEnumerable<PhysicalAddress>> GetList();
        Task Add(PhysicalAddress physicalAddress);
        void UpdateRecord(PhysicalAddress physicalAddress);
        Task DeleteRecord(PhysicalAddress physicalAddress);
    }
}
