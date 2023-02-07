using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class PlaneConfiguration : IEntityTypeConfiguration<plane>
    {
        public void Configure(EntityTypeBuilder<plane> builder)
        {

            builder.HasKey(p => p.PlaneId);  // on fait  le  parametrage  de la  clé  primaire  
            //builder.ToTable(nameof(plane));
            builder.ToTable("MyPlanes");//permet  de changer le Nom  de la table  

            //pour changer  le nom de  la  propriete 
            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");


        }
    }
}
