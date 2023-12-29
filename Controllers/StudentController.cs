using Microsoft.AspNetCore.Mvc;
using Repository_Pattern_Template.Models;
using Repository_Pattern_Template.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Repository_Pattern_Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get() => _studentRepository.GetAllStudents();
        

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentRepository.GetStudentById(id);

            return student is null ? NotFound():student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _studentRepository.AddStudent(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Student student)
        {
            var oldStudent = _studentRepository.GetStudentById(id);
            if (oldStudent is null)
            {
                return BadRequest();
            }
            _studentRepository.EditStudent(oldStudent,student);
            return NoContent();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var student = _studentRepository.GetStudentById(id);

            if (student is null)
            {
                return NotFound();
            }

            _studentRepository.RemoveStudent(student);

            return NoContent();
        }
    }
}
