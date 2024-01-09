namespace ConsoleApp1.J2AM
{
    internal class ProgramJ2AM
    {
        static void MainJ2AM(string[] args)
        {
            Animal animal1 = new Animal();
            var animal2 = new Animal("Lion", 10);
            var animal3 = new Animal("Lion", 10, 20.5, 1d, Diet.Carnivore);
            var animal4 = new Animal(animal3);
            Animal animal5 = new();
            Animal animal6 = new() { Name = "Chat" };

            Zoo zoo = new Zoo() { name = "Beauval", country = "France", city = "Saint-Aignan" },
                zoo2 = new Zoo() { name = "La Flèche" };

            zoo.AddAnimal(animal1);
            zoo.AddAnimal(animal2);
            zoo.MutateAnimal(animal2, age: 15);
            zoo.RemoveAnimal(animal1);

            zoo.DisplayAnimals();
        }
    }

    internal class Animal
    {
        #region Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public Diet Diet { get; set; }

        #endregion

        #region Constructors

        public Animal() : this(string.Empty, 0, 4.12d, 0.54d, Diet.Carnivore) { }
        public Animal(string name, int age)
            => (Name, Age, Weight, Height, Diet) = (name, age, 0d, 0d, Diet.Omnivore);
        public Animal(string name, int age, double weight, double height, Diet diet)
            => (Name, Age, Weight, Height, Diet) = (name, age, weight, height, diet);

        public Animal(Animal same) => (Name, Age, Weight, Height) = (same.Name, same.Age, same.Weight, same.Height);

        #endregion

        public override string ToString()
        {
            return $"{this.Name ?? "<NoName>"} age {this.Age} : w {this.Weight}, h {this.Height}";
        }
    }

    internal class Zoo
    {
        public string name;
        public string city;
        public string country;
        private List<Animal> arrayOfAnimals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            if (!this.arrayOfAnimals.Contains(animal))
                this.arrayOfAnimals.Add(animal);
        }
        public void RemoveAnimal(Animal animal)
        {
            this.arrayOfAnimals.Remove(animal);
        }

        public void MutateAnimal(Animal animal, string name = null, int? age = null)
        {
            if (this.arrayOfAnimals.Contains(animal))
            {
                if (!string.IsNullOrWhiteSpace(name))
                    animal.Name = name;
                if (age.HasValue)
                    animal.Age = age.Value;
            }
        }

        public void DisplayAnimals()
        {
            foreach (var animal in this.arrayOfAnimals)
                Console.WriteLine(animal);
        }
    }

    internal enum Diet
    {
        Herbivore = 1,
        Carnivore = 1 << 1,
        Omnivore = Herbivore | Carnivore
    }
}
