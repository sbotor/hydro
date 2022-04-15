namespace Hydro.Data.Entities
{
    public class Drink
    {
        public long Id { get; set; }

        public int VolMl { get; set; }

        public DateTime AddedDateTime { get; set; } = DateTime.Now;

        public DrinkType? Type { get; set; }

        public DrinkContainer? Container { get; set; }
    }
}
