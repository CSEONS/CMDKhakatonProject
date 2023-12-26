namespace CMDKhakatonProject.Service.Interfaces
{
    public interface IDatabaseService
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
