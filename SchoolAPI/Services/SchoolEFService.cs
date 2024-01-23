using DalJ4;
using DalJ4.Model;

namespace SchoolAPI.Services
{
    public class SchoolEFService : ISchoolAPI
    {
        private SchoolContext schoolContext;

        public SchoolEFService()
        {
            this.schoolContext = new SchoolContext();
            this.schoolContext.Database.EnsureCreated();
        }

        public int CreateStudent(Student student)
        {
            this.schoolContext.Students.Add(student);
            this.schoolContext.SaveChanges();

            return schoolContext.Students.Max(x => x.Id);
        }

        public Student GetStudentById(int id)
        {
            return this.schoolContext.Students.FirstOrDefault(x => x.Id == id);
        }

        public List<Student> GetStudents()
        {
            return this.schoolContext.Students.ToList();
        }

        public void RemoveStudent(int id)
        {
            var student = this.schoolContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null) throw new Exception("N'existe pas");

            this.schoolContext.Remove(student);
            this.schoolContext.SaveChanges();
        }

        public void UpdateStudent(int id, Student student)
        {
            var stud = this.schoolContext.Students.FirstOrDefault(x => x.Id == id);
            if (stud == null) throw new Exception("N'existe pas");

            this.schoolContext.Students.Remove(stud);
            this.schoolContext.Students.Add(student);
            this.schoolContext.SaveChanges();
        }
    }
}
