namespace Hydro.Api.Dto.Drink
{
    public class DrinkPostDto
    {
        public int VolMl { get; set; }

        public long? BeverageId { get; set; }

        public long? ContainerId { get; set; }
    }
}
