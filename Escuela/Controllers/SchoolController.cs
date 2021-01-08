using SchoolCrud.Contexts;
using SchoolCrud.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public SchoolController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Courses> GetCourses()
        {
            var data = _context.Courses.ToList();
            return data;
        }
        [HttpGet("{id}")]
        public Courses GetCoursesId(int id)
        {
            var Escuela = _context.Courses.FirstOrDefault(p => p.IdCourse == id);
            return Escuela;
        }
        [HttpPost]
        public IActionResult AddCourses([FromBody]Courses Course)
        {
            _context.Courses.Add(Course);
            _context.SaveChanges();
            return Ok("Saved");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var Course = GetCoursesId(id);
            if (Course != null)
            {
                _context.Remove(Course);
                _context.SaveChanges();
                return Ok("Removed");
            }
            return BadRequest("Error");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody]Courses courses)
        {
            if (courses.IdCourse==id)
            {
                _context.Entry(courses).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok("Updated");
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
