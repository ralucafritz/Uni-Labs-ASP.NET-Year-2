using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab210.DAL.Entities
{
    public class Student
    {
        [Key]
        public int Id { get; set; } // StudentId 
        public string Name { get; set; }
        public virtual StudentAddress StudentAddress { get; set; }
        public virtual ICollection<StudentGrade> StudentGrades { get; set; }
        public virtual ICollection<StudentTeacher> StudentTeachers { get; set; }

    }
}
