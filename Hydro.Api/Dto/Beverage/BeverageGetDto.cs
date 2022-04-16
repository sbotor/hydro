using static Hydro.Data.Entities.Beverage;

namespace Hydro.Api.Dto.Beverage
{
    public class BeverageGetDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public SweetnessLevel Sweetness { get; set; }

        public bool Alcoholic { get; set; }
    }
}
