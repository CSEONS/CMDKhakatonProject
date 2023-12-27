using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;

namespace CMDKhakatonProject.Domain.Repositories.EF
{
    public class EFRestourantRepository : IRepository<Restourant>
    {
        public void Add(Restourant restourant)
        {
            throw new NotImplementedException();
        }

        public List<Restourant> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Restourant> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Restourant GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Restourant GetByIdEager(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
