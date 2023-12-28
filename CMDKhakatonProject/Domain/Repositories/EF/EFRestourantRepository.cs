using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMDKhakatonProject.Domain.Repositories.EF
{
    public class EFRestourantRepository : IRepository<Restaurant>
    {
        private readonly ApplicationDbContext _context;

        public EFRestourantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Restaurant restourant)
        {
            _context.Add(restourant);
            _context.SaveChanges();
        }

        public List<Restaurant> GetAll()
        {
            return _context.Restournats.ToList();   
        }

        public List<Restaurant> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetByIdEager(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
