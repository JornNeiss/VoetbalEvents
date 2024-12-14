using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VoetbalEvents.Models
{
    public class reservering
    {
        [Key]
        public int ReserveringID { get; set; }

        [Required]
        public DateTime Datum { get; set; }        

        [ForeignKey("Wedstrijd")]
        public int WedstrijdID { get; set; } // Foreign key naar Wedstrijd
        public Wedstrijd Wedstrijd { get; set; } // Navigatie naar Wedstrijd
    }

}