using PresentationEF.Model;

namespace PresentationEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClassContext classContext = new ClassContext();

            classContext.Database.EnsureCreated();

            classContext.People.Add(
                new Person()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Pets = new List<Animal>()
                    {
                        new Animal()
                        {
                            Name = "Milou",
                            Species = "Dog"
                        }
                    }
                }
            );

            classContext.SaveChanges();
        }
    }
}