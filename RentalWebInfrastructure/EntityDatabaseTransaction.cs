using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RentalWebInfrastructure.Infrastructure
{
    public class EntityDatabaseTransaction : IDatabaseTransaction
    {
        private IDbContextTransaction _transaction;
        public EntityDatabaseTransaction(DbContext dbContext)
        {
            _transaction = dbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            _transaction.DisposeAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
        }
    }
}
