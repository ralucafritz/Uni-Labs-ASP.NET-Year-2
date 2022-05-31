using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab210.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lab210.DAL.Configurations
{
    public class StudentAddressConfiguration : IEntityTypeConfiguration<StudentAddress>
    {
        public void Configure(EntityTypeBuilder<StudentAddress> builder)
        {
            builder.Property(x => x.City)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            //builder.HasOne(p => p.Student)
            //    .WithOne(p => p.StudentAddress)
            //    .HasForeignKey<StudentAddress>(p => p.StudentId);


        }
    }
}
