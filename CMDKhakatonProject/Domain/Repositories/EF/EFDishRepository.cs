using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMDKhakatonProject.Domain.Repositories.EF
{
    public class EFDishRepository : IRepository<Dish>
    {
        private readonly ApplicationDbContext _context;

        public EFDishRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Dish dish)
        {
            _context.Dishes.Add(dish);
            _context.SaveChanges();
        }

        public List<Dish> GetAll()
        {
            return _context.Dishes.ToList();
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
