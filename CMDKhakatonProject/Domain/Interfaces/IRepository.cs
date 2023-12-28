using CMDKhakatonProject.Domain.Entities;

namespace CMDKhakatonProject.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T GetById(Guid id);
        T GetByIdEager(Guid id);
        void Delete(T entity);
        List<T> GetAll();
        List<T> GetAllEager();
    }
}
