using Hydro.Data.Entities;
using Hydro.Data.Repositories;

namespace Hydro.Data
{
    public class UnitOfWork
    {
        private ApplicationDbContext _context;

        private GenericRepository<Drink>? _drinks;
        private GenericRepository<DrinkContainer>? _drinkContainers;
        private GenericRepository<DrinkType>? _drinkTypes;

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

        public GenericRepository<DrinkContainer> DrinkContainers
        {
            get
            {
                if (_drinkContainers == null)
                {
                    _drinkContainers = new GenericRepository<DrinkContainer>(_context);
                }
                return _drinkContainers;
            }
        }

        public GenericRepository<DrinkType> DrinkTypes
        {
            get
            {
                if (_drinkTypes == null)
                {
                    _drinkTypes = new GenericRepository<DrinkType>(_context);
                }
                return _drinkTypes;
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
