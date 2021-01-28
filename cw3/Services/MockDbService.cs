
using System.Collections.Generic;


namespace cw3.Services
{
    public class MockDbService : IDbService
    {
        private static List<Student> _students = new List<Student>
        {
            new Student{IdStudent=1,FirstName="Jan", LastName="Kowalski", IndexNumber = "s9864" },
            new Student{IdStudent=2,FirstName="Adam", LastName="Nowak", IndexNumber = "s9834" },
            new Student{IdStudent=3,FirstName="Ewa", LastName="Karolak", IndexNumber = "s9864" }
        };

        public List<Student> GetStudents()
        {
            return (_students);
        }
        public void AddStudent(Student student)
        {
            _students.Add(student);
            
        }
        public void UpdateStudent(int id)
        {
            Student student = _students.Find(x => x.IdStudent == id);

        }
        public void RemoveStudent(int id)
        {
            Student student = _students.Find(x => x.IdStudent == id);
            _students.Remove(student);
        }


    }
}
