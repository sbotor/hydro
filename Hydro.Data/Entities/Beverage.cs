using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hydro.Data.Entities
{
    public class Beverage
    {
        private const int _maxNameLength = 64;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MinLength(3)]
        [MaxLength(_maxNameLength)]
        public string Name { get; set; } = string.Empty;

        public SweetnessLevel Sweetness { get; set; }

        public bool Alcoholic { get; set; }

        public ICollection<Drink> Drinks { get; set; }

        public enum SweetnessLevel
        {
            Unsweetened,
            Low,
            Medium,
            High
        }
    }
}
