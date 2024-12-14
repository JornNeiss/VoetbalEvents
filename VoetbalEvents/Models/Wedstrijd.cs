using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VoetbalEvents.Models
{
    public class Wedstrijd
    {
        [Key]
        public int WedstrijdID { get; set; }

        [Required]
        [StringLength(200)]
        public string Naam { get; set; }

        [StringLength(1000)]
        public string Beschrijving { get; set; }

        [Required]
        public DateTime Datum { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Er moet minimaal 1 kaart beschikbaar zijn.")]
        public int MaxKaarten { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Toeschouwers { get; set; }

        [NotMapped]
        public int BeschikbareKaarten => MaxKaarten - Toeschouwers;

        public List<reservering> reserverings { get; set; } = new List<reservering>(); 

        [StringLength(200)]
        public string? Foto { get; set; }
    }
}