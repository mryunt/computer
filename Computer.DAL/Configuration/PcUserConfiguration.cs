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
    public class PcUserConfiguration : IEntityTypeConfiguration<PcUser>
    {
        public void Configure(EntityTypeBuilder<PcUser> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PcId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.HasOne(p => p.UserFK).WithMany(p => p.PcUsers).HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.PcFK).WithMany(p => p.PcUsers).HasForeignKey(p => p.PcId);
        }
    }
}
