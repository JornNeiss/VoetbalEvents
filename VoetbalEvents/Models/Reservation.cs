using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Info_Systeem_Eventplanner.Models;

namespace Info_Systeem_Eventplanner
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [Required]
        public DateTime Active { get; set; }

        [ForeignKey("AppUser")]
        public int UserID { get; set; } // Foreign key naar AppUser 
        public AppUser AppUser { get; set; } // Navigatie naar AppUser 

        [ForeignKey("Event")]
        public int EventID { get; set; } // Foreign key naar Event
        public Event Event { get; set; } // Navigatie naar Event
    }

}