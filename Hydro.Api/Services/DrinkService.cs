using AutoMapper;
using Hydro.Api.Dto;
using Hydro.Api.Exceptions;
using Hydro.Data;
using Hydro.Data.Entities;

namespace Hydro.Api.Services
{
    public class DrinkService
    {
        private UnitOfWork _work;
        private IMapper _mapper;

        public DrinkService(ApplicationDbContext context, IMapper mapper)
        {
            _work = new UnitOfWork(context);
            _mapper = mapper;
        }

        public IEnumerable<DrinkGetDto> GetAllDrinks()
        {
            return _work.Drinks.Get().Select(
                drink => _mapper.Map<DrinkGetDto>(drink));
        }

        public DrinkGetDto GetDrinkById(long id)
        {
            var drink = _work.Drinks.GetById(id) ??
                throw new NotFoundException($"Drink with id {id} does not exist.");

            return _mapper.Map<DrinkGetDto>(drink);
        }

        public long AddDrink(DrinkPostDto drinkDto)
        {
            Drink drink = _mapper.Map<Drink>(drinkDto);
            _work.Drinks.Add(drink);
            _work.Complete();
            
            return drink.Id;
        }

        public void UpdateDrink(long id, DrinkPutDto drinkDto)
        {
            var drink = _work.Drinks.GetById(id) ??
                throw new NotFoundException($"Drink with id {id} does not exist.");

            Console.WriteLine(drinkDto.VolMl);
            Console.WriteLine(drinkDto.ContainerId);
            Console.WriteLine(drinkDto.TypeId);
            
            _mapper.Map(drinkDto, drink);
            _work.Drinks.Update(drink);
            _work.Complete();
        }

        public void RemoveDrink(long id)
        {
            var drink = _work.Drinks.GetById(id) ??
                throw new NotFoundException($"Drink with id {id} does not exist.");

            _work.Drinks.Remove(drink);
            _work.Complete();
        }
    }
}
