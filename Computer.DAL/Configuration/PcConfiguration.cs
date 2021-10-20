using Computer.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer.DAL.Configuration
{
    public class PcConfiguration : IEntityTypeConfiguration<Pc>
    {
        public void Configure(EntityTypeBuilder<Pc> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Price).IsRequired();
        }
    }
}
