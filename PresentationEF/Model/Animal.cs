using System.ComponentModel.DataAnnotations;

namespace PresentationEF.Model
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Species { get; set; }
    }
}
