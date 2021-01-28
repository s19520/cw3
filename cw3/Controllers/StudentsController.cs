
using cw3.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

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
        private const string ConString = "Data Source=DESKTOP-RSTT48M\\SQLEXPRESS;Initial Catalog=apbd;Integrated Security=True";
        [HttpGet]
        public IActionResult GetStudents()
        {
            IEnumerable<Student> _students = new List<Student> { };
            using (var client = new SqlConnection(ConString))
            using (var com=new SqlCommand())
            {
                
                com.Connection = client;
                com.CommandText = "select * from dbo.Student inner join  dbo.Enrollment on dbo.Student.IdEnrollment=dbo.Enrollment.IdEnrollment inner join dbo.Studies on dbo.Enrollment.IdStudy=dbo.Studies.IdStudy";
                client.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {   
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    st.StartDate = dr["StartDate"].ToString();
                    st.StudyName = dr["Name"].ToString();
                    _students = _students.Append(st);
                }

            
            }
            return Ok(_students);
            

        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(string id)
        {
            IEnumerable<Student> _students = new List<Student> { };
            using (var client = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {

                com.Connection = client;
                com.CommandText = "select * from dbo.Student inner join  dbo.Enrollment on dbo.Student.IdEnrollment=dbo.Enrollment.IdEnrollment inner join dbo.Studies on dbo.Enrollment.IdStudy=dbo.Studies.IdStudy where IndexNumber=@index";
                SqlParameter par = new SqlParameter();
                par.Value = id;
                par.ParameterName = "index";
                com.Parameters.Add(par);
                client.Open();
                var dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var st = new Student();
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.Semester = dr["Semester"].ToString();
                    st.StartDate = dr["StartDate"].ToString();
                    st.StudyName = dr["Name"].ToString();
                    _students = _students.Append(st);
                }


            }
            return Ok(_students);


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
            //_dbService.UpdateStudent(id);
            return Ok("Aktualizacja dokończona");
        }
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(int id )
        {

            //_dbService.RemoveStudent(id);
            return Ok("Usuwanie dokończone");
        }
    }
}
