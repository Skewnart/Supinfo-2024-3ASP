using System.ComponentModel.DataAnnotations;

namespace DalJ4.Model
{
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
