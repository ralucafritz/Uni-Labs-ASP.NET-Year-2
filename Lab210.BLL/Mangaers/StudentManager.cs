using Lab210.BLL.Interfaces;
using Lab210.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab210.BLL.Mangaers
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepository _studentRepo;
        public StudentManager(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public async Task<List<string>> ModifyStudent()
        {
            var students = await _studentRepo.GetAll();
            var list = new List<string>();

            foreach(var student in students)
            {
                list.Add($"StudentName: {student.Name}");

            }

            return list;
        }
    }
}
