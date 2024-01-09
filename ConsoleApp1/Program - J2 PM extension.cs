namespace ConsoleApp1J2PME
{
    internal class ProgramJ2PME
    {
        static void MainJ2PME(string[] args)
        {
            string chaine = "thomas";
            //Console.WriteLine(chaine.ToUpperLower());

            List<int> numbers = new List<int>() { 1, 6, 9, 43, 234 };
            foreach(var number in numbers.When(x => x > 10))
            {
                //Console.WriteLine(number);
            }

            List<Person> people = new List<Person>{
                new Person("John", "Doe", 28),
                new Person("Curt", "Cobain", 27),
                new Person("Dan", "Reynolds", 36),
                new Person("Christophe", "Lemoine", 45),
                new Person("Thomas", "Pesquet", 45)
            };

            var names = people
                .Where(x => x.Age > 30)
                .OrderByDescending(x => x.Age)
                //.Select(x => x.Prenom)
                .Skip(1)
                .FirstOrDefault(x => x.Age > 40);
            //.ToList();

            //Console.WriteLine(string.Join("\n", names));
        }
    }

    public static class StringExtensions
    {
        public static string ToUpperLower(this string str)
        {
            return $"{Char.ToUpper(str.First())}{string.Join("", str.Skip(1)).ToLower()}";
        }

        public static IEnumerable<T> When<T>(this List<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                    yield return item;
            }
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
