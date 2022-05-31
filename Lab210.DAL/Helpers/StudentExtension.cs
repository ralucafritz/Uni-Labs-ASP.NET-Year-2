using Lab210.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab210.DAL.Helpers
{
    public static class StudentExtension
    {
        public static IQueryable<Student> IncludeGrade(this IQueryable<Student> students)
        {
            return students.Include(x => x.StudentGrades);
        }

        public static IQueryable<Student> WhereClauses(this IQueryable<Student> students)
        {
            return students
                .IncludeGrade()
                .Where(x => x.Name == "Mia")
                .Where(x => x.StudentAddress.City == "Bucharest")
                .Where(x => x.StudentAddress.Zipcode == 12313);
        }
    }
}
