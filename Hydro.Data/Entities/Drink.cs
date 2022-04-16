using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydro.Data.Entities
{
    public class Drink
    {
        private const int _maxVol = 15000;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Range(1, _maxVol)]
        public int VolMl { get; set; }

        public DateTime AddedDateTime { get; set; } = DateTime.Now;

        public long? BeverageId { get; set; }
        public Beverage? Beverage { get; set; }

        public long? ContainerId { get; set; }
        public Container? Container { get; set; }
    }
}
