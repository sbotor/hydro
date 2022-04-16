using Hydro.Data.Entities;
using Hydro.Data.Repositories;

namespace Hydro.Data
{
    public class UnitOfWork
    {
        private ApplicationDbContext _context;

        private GenericRepository<Drink>? _drinks;
        private GenericRepository<Container>? _containers;
        private GenericRepository<Beverage>? _beverages;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public GenericRepository<Drink> Drinks
        {
            get
            {
                if (_drinks == null)
                {
                    _drinks = new GenericRepository<Drink>(_context);
                }
                return _drinks;
            }
        }

        public GenericRepository<Container> Containers
        {
            get
            {
                if (_containers == null)
                {
                    _containers = new GenericRepository<Container>(_context);
                }
                return _containers;
            }
        }

        public GenericRepository<Beverage> Beverages
        {
            get
            {
                if (_beverages == null)
                {
                    _beverages = new GenericRepository<Beverage>(_context);
                }
                return _beverages;
            }
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void CompleteAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
