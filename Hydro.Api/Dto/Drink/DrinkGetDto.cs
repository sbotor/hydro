namespace Hydro.Api.Dto.Drink
{
    public class DrinkGetDto
    {
        public long Id { get; set; }

        public int VolMl { get; set; }

        public DateTime AddedDateTime { get; set; }

        public long? BeverageId { get; set; }

        public long? ContainerId { get; set; }
    }
}
