using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Infrastructure
{
  public interface IDatabaseTransaction : IDisposable
    {
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
