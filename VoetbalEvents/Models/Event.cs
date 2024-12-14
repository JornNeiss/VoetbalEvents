using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VoetbalEvents.Models;

namespace Info_Systeem_Eventplanner.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [StringLength(200)]
        public string EventName { get; set; }

        [StringLength(1000)]
        public string EventDescription { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "MaxParticipants must be at least 1.")]
        public int MaxParticipants { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Participants { get; set; } 

        [NotMapped]
        public int AvailableSpots => MaxParticipants - Participants;

        public List<Reservation> Reservations { get; set; } = new List<Reservation>(); // Relatie naar Reservation

        [StringLength(200)]
        public string? ImagePath { get; set; }
    }
}
