
using System.Collections.Generic;


namespace cw3.Services
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        public void AddStudent(Student student);
        public void RemoveStudent(int id);
        public void UpdateStudent(int id);


    }
}
