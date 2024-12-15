using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VoetbalEvents.Models;

namespace VoetbalEvents.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet <Wedstrijd> Wedstrijds { get; set; }
    public DbSet <reservering> reserverings { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);


        // een wedstrijd kan meerdere reserveringen hebben
        modelBuilder.Entity<reservering>()
            .HasOne(e => e.Wedstrijd)
            .WithMany(ev => ev.reserverings)
            .HasForeignKey(e => e.WedstrijdID);

        // Seed data for wedstrijden
        modelBuilder.Entity<Wedstrijd>().HasData(
            new Wedstrijd
            {
                WedstrijdID = 1,
                Naam = "Roda JC - MVV Maastricht",
                Beschrijving = "De limburgse derby tussen Roda jc Kerkrade en MVV Maastricht",
                Datum = DateTime.Now.AddDays(30),
                MaxKaarten = 2000,
                Foto = "/images/RJC.jpg"
            },
            new Wedstrijd
            {
                WedstrijdID = 2,
                Naam = "Alemania Aachen - RW Essen",
                Beschrijving = "De degradatie kraker in de 3. Bundesliga tussen Alemannia Aachen en RW Essen",
                Datum = DateTime.Now.AddDays(31),
                MaxKaarten = 1400,
                Foto = "/images/Alemannia.jpg"
            },
            new Wedstrijd
            {
                WedstrijdID = 3,
                Naam = "AC Milan - Napoli",
                Beschrijving = "De wedstrijd tussen de 2 italiaanse groot machten: AC Milan en Napoli",
                Datum = DateTime.Now.AddDays(60),
                MaxKaarten = 700,
                Foto = "/images/ACMilan.jpg"
            }
        );

        modelBuilder.Entity<reservering>().HasData(
            new reservering{ ReserveringID = 1, WedstrijdID = 1 },
            new reservering{ ReserveringID = 2, WedstrijdID = 2 },
            new reservering{ ReserveringID = 3, WedstrijdID = 3 }
        );

        
        
    }
}

