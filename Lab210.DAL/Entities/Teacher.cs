using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab210.DAL.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<StudentTeacher> StudentTeachers { get;set; }

    }
}
