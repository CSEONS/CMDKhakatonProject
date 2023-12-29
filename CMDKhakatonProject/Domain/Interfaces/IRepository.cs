using CMDKhakatonProject.Domain.Entities;

namespace CMDKhakatonProject.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        T GetById(string id);
        T GetByIdEager(string id);
        void Delete(T entity);
        List<T> GetAll();
        List<T> GetAllEager();
    }
}
