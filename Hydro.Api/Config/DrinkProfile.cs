using AutoMapper;
using Hydro.Api.Dto;
using Hydro.Data.Entities;

namespace Hydro.Api.Config
{
    public class DrinkProfile : Profile
    {
        public DrinkProfile()
        {
            IgnoreNullable<int>();
            IgnoreNullable<long>();
            
            CreateMap<DrinkPostDto, Drink>();
            CreateMap<Drink, DrinkGetDto>();

            CreateMap<DrinkPutDto, Drink>().ForAllMembers(
                options => options.Condition((_, _, srcMem) => srcMem != null));
        }

        private void IgnoreNullable<T>()
        {
            CreateMap<T?, T>().ConvertUsing((src, dest) => src ?? dest);
        }
    }
}
