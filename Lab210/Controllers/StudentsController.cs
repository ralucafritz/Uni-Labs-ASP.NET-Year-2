using Lab210.DAL;
using Lab210.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab210.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public StudentsController(AppDbContext context)
        {
            // var context = new AppDbContext(); -> se distruge daca e creata asa
            _context = context;
        }

        [HttpPost("AddStudent")]

        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if(string.IsNullOrEmpty(student.Name))
            {
                return BadRequest("Name is null");
            }

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Get/{id}")]

        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            //var student = await _context.Students.FindAsync(id);
            var student = await _context.Students.Where(x => x.Id == id).Include(x=>x.StudentAddress).FirstOrDefaultAsync();

            return Ok(student);
        }

        [HttpGet("get-select")]
        public async Task<IActionResult> GetStudentGradesSelect()
        {
            var studentGrades = await _context.StudentGrades.Select(x => new { Id = x.Id, GradePerStudents = x.Grade }).ToListAsync();

            return Ok(studentGrades);
        }

        [HttpGet("get-join")]
        public async Task<IActionResult> GetStudentsGradesJoin()
        {
            var student = await _context
                .Students
                .Include(x => x.StudentGrades)
                .Where(x => x.StudentGrades.Count > 1)
                .ToListAsync();

            return Ok(student);
        }

        [HttpGet("get-orderby")]
        public async Task<IActionResult> GetStudentsGradesOrderBy()
        {
            var student = await _context
                .Students
                .Include(x => x.StudentGrades)
                .Where(x => x.StudentGrades.Count > 1)
                //.OrderBy(x => x.Name)
                .OrderByDescending(x => x.Name)
                .Select(x => x.Name)
                .ToListAsync();

            return Ok(student);
        }

        [HttpPut] // ?id=1&name=stefan
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string name)
        {
            //var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id); // se schimba numele

            // se recomanda:
            var student = await _context.Students.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id); // nu stie ca s-a schimbat ceva => 
            // asa ca trebuie sa folosim codul de la liniile 96 si 98

            student.Name = name;

            // ca sa schimbe cand folosim AsNoTracking():
            //_context.Students.Attach(student); 
            // sau 
            _context.Entry(student).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var studentV2 = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);

            return Ok();
        }

        [HttpGet("jazy-lazy")]
        public async Task<IActionResult> JoinLazy()
        {
            // cand facem query si peste ceva timp vrem sa folosim datele
            // nu sunt tinute in memorie pana nu se foloseste
            var students = _context.Students.AsQueryable();

            return Ok(students);
        }

        [HttpGet("get-group-by")]
        public async Task<IActionResult> GetGroupBy()
        {
            var gradeAverage = _context.StudentGrades
                .GroupBy(x => x.StudentId)
                .Select(x => new
                {
                    Key = x.Key,
                    Average = x.Average(x => x.Grade),
                    Count = x.Count()
                }).ToList();

            return Ok(gradeAverage);
        }


        [HttpGet("get-join-linq")]
        public async Task<IActionResult> GetJoinLinq()
        {
            var students = _context.Students;
            var join = _context.StudentGrades.Join(students, b => b.StudentId, a => a.Id, (b, a) => new
            {
                b.StudentId,
                b.Grade,
                a.Name
            }).ToList();

            return Ok(join);
        }

    }
}
