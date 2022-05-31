using Lab210.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab210.DAL.Configurations
{
    class StudentGradeConfiguration : IEntityTypeConfiguration<StudentGrade>
    {
        public void Configure(EntityTypeBuilder<StudentGrade> builder)
        {
            builder.Property(p => p.Subject)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(p => p.Grade)
                .HasColumnType("decimal(4,2)");
        }
    }
}
