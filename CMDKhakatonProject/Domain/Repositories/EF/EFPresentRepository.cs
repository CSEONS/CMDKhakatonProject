using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;

namespace CMDKhakatonProject.Domain.Repositories.EF
{
    public class EFPresentRepository : IRepository<Present>
    {
        private readonly ApplicationDbContext _contex;

        public EFPresentRepository(ApplicationDbContext context)
        {
            _contex = context;    
        }

        public void Add(Present entity)
        {
            _contex.Add(entity);
            _contex.SaveChanges();
        }

        public void Delete(Present entity)
        {
            throw new NotImplementedException();
        }

        public List<Present> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Present> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Present GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Present GetByIdEager(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
