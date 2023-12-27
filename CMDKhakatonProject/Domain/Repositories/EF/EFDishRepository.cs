using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;

namespace CMDKhakatonProject.Domain.Repositories.EF
{
    public class EFDishRepository : IRepository<Dish>
    {
        private readonly ApplicationDbContext _context;

        public EFDishRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Dish restourant)
        {
            _context.AddAsync(restourant);
            _context.SaveChanges();
        }

        public List<Dish> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Dish> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Dish GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Dish GetByIdEager(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
