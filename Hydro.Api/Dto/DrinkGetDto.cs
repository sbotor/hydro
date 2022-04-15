namespace Hydro.Api.Dto
{
    public class DrinkGetDto
    {
        public long Id { get; set; }

        public int VolMl { get; set; }

        public DateTime AddedDateTime { get; set; }

        public long? TypeId { get; set; }

        public long? ContainerId { get; set; }
    }
}
