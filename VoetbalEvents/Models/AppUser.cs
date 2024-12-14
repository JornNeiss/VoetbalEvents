using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using VoetbalEvents.Models;

namespace Info_Systeem_Eventplanner.Models;
public class AppUser : IdentityUser
{
    [Key]
    public int UserID { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string? TelephoneNumber { get; set; }

    [Required]
    public bool IsAdmin { get; set; } = false; // Standaard is een lid geen Admin (Organisator of medewerker) 

    // Relaties naar events en reservations
    public List<Event> Events { get; set; } = new List<Event>();
    public List<Reservation> reservations { get; set; } = new List<Reservation>();
}