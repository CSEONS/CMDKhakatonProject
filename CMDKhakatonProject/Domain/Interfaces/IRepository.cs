using CMDKhakatonProject.Domain.Entities;

namespace CMDKhakatonProject.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T restourant);
        T GetById(Guid id);
        T GetByIdEager(Guid id);
        List<T> GetAll();
        List<T> GetAllEager();
    }
}
