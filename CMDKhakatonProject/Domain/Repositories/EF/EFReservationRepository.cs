using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;

namespace CMDKhakatonProject.Domain.Repositories.EF
{
    public class EFReservationRepository : IRepository<Reservation>
    {
        private readonly ApplicationDbContext _context;

        public EFReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Reservation entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Reservation GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Reservation GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Reservation GetByIdEager(Guid id)
        {
            throw new NotImplementedException();
        }

        public Reservation GetByIdEager(string id)
        {
            throw new NotImplementedException();
        }
    }
}
