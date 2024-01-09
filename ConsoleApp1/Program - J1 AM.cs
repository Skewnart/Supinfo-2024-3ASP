namespace ConsoleApp1.J1AM
{
    internal class ProgramJ1AM
    {
        public static string AskString(string wut)
        {
            Console.Write($"{wut} : ");
            return Console.ReadLine();
        }
        public static int AskInt(string wut)
        {
            Console.Write($"{wut} : ");
            int ret = default(int);
            if (!int.TryParse(Console.ReadLine(), out ret))
                throw new Exception("int attendu");

            return ret;
        }

        static void MainJ1AM(string[] args)
        {
            string prenom = AskString("prénom");
            string nom = AskString("nom");

            int age = AskInt("âge");

            Console.WriteLine($"Bonjour {prenom} {nom}, d'âge {age}");

            string adresse = AskString("adresse");
            int commune = AskInt("commune");
            int codepostal = AskInt("code postal");

            if (string.IsNullOrEmpty(adresse) || commune == default(int) || codepostal == default(int))
            {
                throw new Exception("pas bon");
            }

            Console.WriteLine($"Adresse : {adresse}, commune : {commune}, code postal : {codepostal}");
            //Console.WriteLine($"Adresse : {adresse?.ToUpper() ?? "<none>"}, commune : {(commune > 0 ? commune : "<none>")}, code postal : {(codepostal > 0 ? codepostal : "<none>")}");
        }

    }
}
