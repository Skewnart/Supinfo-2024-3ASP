using System.ComponentModel.DataAnnotations;

namespace DalJ4.Model
{
    public class Classroom
    {
        [Key]
        public int Id { get; set; }

        public List<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
    }
}
