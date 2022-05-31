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

   public class StudentTeacherConfiguration : IEntityTypeConfiguration<StudentTeacher>
    {
        public void Configure(EntityTypeBuilder<StudentTeacher> builder)
        {
            builder.HasOne(p => p.Student)
                .WithMany(p => p.StudentTeachers)
                .HasForeignKey(p => p.StudentId);

            builder.HasOne(p => p.Teacher)
                .WithMany(p => p.StudentTeachers)
                .HasForeignKey(p => p.TeacherId);
        }
    }
    
}
