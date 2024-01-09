namespace ConsoleApp1.J2PMp1
{
    internal class ProgramJ2PMp1
    {
        static void MainJ2PMp1(string[] args)
        {
            Person[] people = {
                new Person("John", "Doe", 28),
                new Person("Curt", "Cobain", 27),
                new Person("Dan", "Reynolds", 36),
                new Person("Christophe", "Lemoine", 45),
                new Person("Thomas", "Pesquet", 45)
            };

            //Array.Sort(people);
            // -> InvalidOperationException : 'Failed to compare two elements in the array'
            // Donc on implémente l'interface IComparable

            //Array.Sort(people); // Maintenant que l'interface est implémentée, ça fonctionne
            //Console.WriteLine(string.Join("\n", people.ToList()));

            BubbleSort(people);
            Console.WriteLine(string.Join("\n", people.ToList()));
        }

        static void BubbleSort(Person[] people)
        {
            for (int i = people.Length; i > 1; i--)
                for (int j = 0; j < i - 1; j++)
                    if (people[j].CompareTo(people[j + 1]) == 1)
                        (people[j], people[j + 1]) = (people[j + 1], people[j]);
        }
    }

    internal class Person : IComparable<Person>
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }

        public Person(string prenom, string nom, int age) => (Nom, Prenom, Age) = (nom, prenom, age);

        public override string ToString()
        {
            return $"{this.Prenom} {this.Nom}, {this.Age} ans";
        }

        public int CompareTo(Person? obj)
        {
            var other = obj!;

            if (this.Age != other.Age) return this.Age > other.Age ? 1 : -1;
            if (!(this.Prenom.Equals(other.Age))) return this.Prenom.CompareTo(other.Prenom);
            if (!(this.Nom.Equals(other.Nom))) return this.Nom.CompareTo(other.Nom);

            return 0;
        }
    }
}
