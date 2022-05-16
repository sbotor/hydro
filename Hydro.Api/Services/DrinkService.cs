using AutoMapper;
using Hydro.Api.Dto.Drink;
using Hydro.Api.Exceptions;
using Hydro.Data;
using Hydro.Data.Entities;

namespace Hydro.Api.Services
{
    public class DrinkService
    {
        private readonly UnitOfWork _work;
        private readonly IMapper _mapper;

        public DrinkService(ApplicationDbContext context, IMapper mapper)
        {
            _work = new UnitOfWork(context);
            _mapper = mapper;
        }

        public IEnumerable<DrinkGetDto> GetAllDrinks()
        {
            return _work.Drinks.Get()
                .Select(_mapper.Map<Drink, DrinkGetDto>);
        }

        public DrinkGetDto GetDrinkById(long id)
        {
            Drink drink = _work.Drinks.GetById(id) ??
                throw new NotFoundException("Drink", id);

            return _mapper.Map<DrinkGetDto>(drink);
        }

        public long AddDrink(DrinkPostDto drinkDto)
        {
            if (drinkDto.BeverageId is long bevId && !_work.Beverages.ExistsById(bevId))
            {
                throw new NotFoundException("Beverage", bevId);
            }

            if (drinkDto.ContainerId is long conId && !_work.Containers.ExistsById(conId))
            {
                throw new NotFoundException("Container", conId);
            }

            Drink drink = _mapper.Map<Drink>(drinkDto);

            _work.Drinks.Add(drink);
            _work.Complete();

            return drink.Id;
        }

        public void UpdateDrink(long id, DrinkPutDto drinkDto)
        {
            Drink drink = _work.Drinks.GetById(id) ??
                throw new NotFoundException("Drink", id);

            if (drinkDto.BeverageId is long bevId && !_work.Beverages.ExistsById(bevId))
            {
                throw new NotFoundException("Beverage", bevId);
            }

            if (drinkDto.ContainerId is long conId && !_work.Containers.ExistsById(conId))
            {
                throw new NotFoundException("Container", conId);
            }

            _mapper.Map(drinkDto, drink);
            _work.Drinks.Update(drink);
            _work.Complete();
        }

        public void RemoveDrinkById(long id)
        {
            Drink drink = _work.Drinks.GetById(id) ??
                throw new NotFoundException("Drink", id);

            _work.Drinks.Remove(drink);
            _work.Complete();
        }
    }
}
