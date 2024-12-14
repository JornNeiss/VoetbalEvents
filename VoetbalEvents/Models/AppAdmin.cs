using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using VoetbalEvents.Models;

namespace VoetbalEvents
{
    public class AppAdmin
    {
        public int EventID { get; set; }
      
        public int UserID { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}