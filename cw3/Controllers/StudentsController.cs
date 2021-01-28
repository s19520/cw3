
using cw3.Services;
using Microsoft.AspNetCore.Mvc;
using System;


namespace cw3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IDbService _dbService;
        public StudentsController(IDbService service)
        {
            _dbService = service;
        }
        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }
        [HttpPost]
        public IActionResult createStudent (Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            _dbService.AddStudent(student);
            return Ok(student);
        }
        [HttpPut("{id}")]
         public IActionResult updateStudent (int id)
        {
            _dbService.UpdateStudent(id);
            return Ok("Aktualizacja dokończona");
        }
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(int id )
        {

            _dbService.RemoveStudent(id);
            return Ok("Usuwanie dokończone");
        }
    }
}
