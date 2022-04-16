using static Hydro.Data.Entities.Beverage;

namespace Hydro.Api.Dto.Beverage
{
    public class BeveragePutDto
    {
        public string? Name { get; set; }

        public SweetnessLevel? Sweetness { get; set; }

        public bool? Alcoholic { get; set; }
    }
}
