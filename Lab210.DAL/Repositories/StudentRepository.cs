using Lab210.DAL.Entities;
using Lab210.DAL.Interfaces;
using Lab210.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab210.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentModels>> GetAll()
        {
            var students = await (await GetAllQuery()).ToListAsync();
            var list = new List<StudentModels>();
            foreach(var student in students)
            {
                var studentModel = new StudentModels
                {
                    Name = student.Name
                };
                list.Add(studentModel);
            }
            return list;
        }

        public async Task<IQueryable<Student>> GetAllQuery()
        {
            var query = _context.Students.AsQueryable();
            return query;
        }

        public async Task<Student> GetById(int id)
        {
            var student = await _context.Students.FindAsync(id);

            return student;
        }
    }
}
