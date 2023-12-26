using CMDKhakatonProject.Domain;
using CMDKhakatonProject.Service.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace CMDKhakatonProject.Service
{
    public class DatabaseService : IDatabaseService
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public DatabaseService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
    }

}
