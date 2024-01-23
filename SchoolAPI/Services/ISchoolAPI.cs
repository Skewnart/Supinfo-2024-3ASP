using DalJ4.Model;

namespace SchoolAPI.Services
{
    public interface ISchoolAPI
    {
        public List<Student> GetStudents();
        public Student GetStudentById(int id);
        public int CreateStudent(Student student);
        public void UpdateStudent(int id, Student student);
        public void RemoveStudent(int id);
    }
}
