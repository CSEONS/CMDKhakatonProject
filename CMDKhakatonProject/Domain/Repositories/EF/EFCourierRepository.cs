using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;

namespace CMDKhakatonProject.Domain.Repositories.EF
{
    public class EFCourierRepository : IRepository<Courier>
    {
        private readonly IRepository<Courier> _courierRepository;

        public EFCourierRepository()
        {
            
        }
        public void Add(Courier restourant)
        {
            throw new NotImplementedException();
        }

        public void Delete(Courier entity)
        {
            throw new NotImplementedException();
        }

        public List<Courier> GetAll()
        {
            return _courierRepository.GetAll();
        }

        public List<Courier> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Courier GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Courier GetByIdEager(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
