
using System.Collections.Generic;
using System.Linq;

namespace cw3.Services
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students = new List<Student>
        {
            //new Student{IdStudent=1,FirstName="Jan", LastName="Kowalski", IndexNumber = "s9864" },
            //new Student{IdStudent=2,FirstName="Adam", LastName="Nowak", IndexNumber = "s9834" },
            //new Student{IdStudent=3,FirstName="Ewa", LastName="Karolak", IndexNumber = "s9864" }
        };

        public IEnumerable<Student> GetStudents()
        {
            return (_students);
        }
        public void AddStudent(Student student)
        {
            _students = _students.Append(student);
            
        }
        public void UpdateStudent(int id)
        {

        }
        public void RemoveStudent(int id)
        {
            //_students = _students.Except(_students.Where(x => x.IdStudent == id));

        }


    }
}
