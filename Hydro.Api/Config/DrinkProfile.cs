using AutoMapper;
using Hydro.Api.Dto.Beverage;
using Hydro.Api.Dto.Drink;
using Hydro.Data.Entities;

namespace Hydro.Api.Config
{
    public class DrinkProfile : Profile
    {
        public DrinkProfile()
        {
            _ignoreNullable<int>();
            _ignoreNullable<long>();
            _ignoreNullable<bool>();
            
            CreateMap<DrinkPostDto, Drink>();
            CreateMap<Drink, DrinkGetDto>();
            _createUpdateMap<DrinkPutDto, Drink>();

            CreateMap<Beverage, BeverageGetDto>();
            CreateMap<BeveragePostDto, Beverage>();
            _createUpdateMap<BeveragePutDto, Beverage>();
        }

        private void _ignoreNullable<T>()
        {
            CreateMap<T?, T>().ConvertUsing((src, dest) => src ?? dest);
        }

        private void _createUpdateMap<TSource, TDestination>()
        {
            CreateMap<TSource, TDestination>().ForAllMembers(
                options => options.Condition((_, _, srcMem) => srcMem != null));
        }
    }
}
