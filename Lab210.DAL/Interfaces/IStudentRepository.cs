using Lab210.DAL.Entities;
using Lab210.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab210.DAL.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentModels>> GetAll();
        Task<Student> GetById(int id);
        Task Create(Student student);
        Task Delete(Student student);
        Task Update(Student student);
        Task<IQueryable<Student>> GetAllQuery();
    }
}
