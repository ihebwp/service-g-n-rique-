using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)

        {
            // Renomer le  Nom de  la table  assosiative 
            builder.HasMany(p => p.Passengers).WithMany(p => p.Flights).UsingEntity(j => j.ToTable("VolsVoyageurs"));

            //relation one  to  Many 
            builder.HasOne(p => p.Plane)
                .WithMany(p => p.Flights)
                // .HasForeignKey(p => p.PlaneFK)

                .OnDelete(DeleteBehavior.Cascade);

            //Renomer la  clé etrangere
            //on doit  utuliser Has fK  pour changer le  Nom de  la clé etrangere 

        }
    }
}

