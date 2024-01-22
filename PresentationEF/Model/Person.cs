using System.ComponentModel.DataAnnotations;

namespace PresentationEF.Model
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual List<Animal> Pets { get; set; }
    }
}
