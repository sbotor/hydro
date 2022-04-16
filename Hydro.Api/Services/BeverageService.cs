using AutoMapper;
using Hydro.Api.Dto.Beverage;
using Hydro.Api.Exceptions;
using Hydro.Data;
using Hydro.Data.Entities;

namespace Hydro.Api.Services
{
    public class BeverageService
    {
        private readonly UnitOfWork _work;
        private readonly IMapper _mapper;

        public BeverageService(ApplicationDbContext context, IMapper mapper)
        {
            _work = new UnitOfWork(context);
            _mapper = mapper;
        }

        public long AddBeverage(BeveragePostDto beverageDto)
        {
            Beverage bev = _mapper.Map<Beverage>(beverageDto);
            _work.Beverages.Add(bev);
            _work.Complete();

            return bev.Id;
        }

        public IEnumerable<BeverageGetDto> GetAllBeverages()
        {
            return _work.Beverages.Get()
                .Select(_mapper.Map<Beverage, BeverageGetDto>);
        }

        public BeverageGetDto GetBeverageById(long id)
        {
            Beverage bev = _work.Beverages.GetById(id) ??
                throw new NotFoundException("Beverage", id);

            return _mapper.Map<BeverageGetDto>(bev);
        }

        public void UpdateBeverage(long id, BeveragePutDto beverageDto)
        {
            Beverage bev = _work.Beverages.GetById(id) ??
                throw new NotFoundException("Beverage", id);

            _mapper.Map(beverageDto, bev);
            _work.Beverages.Update(bev);
            _work.Complete();
        }

        public void RemoveBeverageById(long id)
        {
            Beverage bev = _work.Beverages.GetById(id) ??
                throw new NotFoundException("Beverage", id);

            _work.Beverages.Remove(bev);
            _work.Complete();
        }
    }
}
