using CMDKhakatonProject.Domain.Entities;
using CMDKhakatonProject.Domain.Interfaces;

namespace CMDKhakatonProject.Domain.Repositories.EF
{
    public class EFDishOrderRepository : IRepository<DishOrder>
    {
        private readonly ApplicationDbContext _context;

        public EFDishOrderRepository(ApplicationDbContext context)
        {
            _context = context;    
        }

        public void Add(DishOrder entity)
        {
            _context.DishOrders.Add(entity);
        }

        public void Delete(DishOrder entity)
        {
            _context.DishOrders.Remove(entity);
        }

        public List<DishOrder> GetAll()
        {
            return _context.DishOrders.ToList();
        }

        public List<DishOrder> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public DishOrder GetById(Guid id)
        {
            return _context.DishOrders.FirstOrDefault(o => o.Id == id);
        }

        public DishOrder GetByIdEager(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
