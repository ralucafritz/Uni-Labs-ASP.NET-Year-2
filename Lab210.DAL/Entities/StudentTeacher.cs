using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab210.DAL.Entities
{
    public class StudentTeacher
    {
        public int id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
