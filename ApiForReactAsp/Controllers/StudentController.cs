using ApiForReactAsp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiForReactAsp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            this._studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentDbContext.Students.ToListAsync();
        }

        [HttpPost]
        [Route("AddStudent")]

        public async Task<Student>AddStudent(Student student)
        {
            await _studentDbContext.Students.AddAsync(student);
            await _studentDbContext.SaveChangesAsync();
            return student;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        
        public async Task<Student>UpdateStudent(Student student)
        {
            _studentDbContext.Entry(student).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
            return student;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]

        public bool DeleteStudent(int id)
        {
            bool a = false;
            var student = _studentDbContext.Students.Find(id);
            if (student != null)
            {
                a=true;
                _studentDbContext.Entry(student).State=EntityState.Deleted;
                _studentDbContext.SaveChangesAsync();

            }

            else
            {
                a=false;
            }
            return a;
        }
    }
}
