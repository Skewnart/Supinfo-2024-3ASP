using DalJ4.Model;
using System.Net.Http.Json;

namespace ClientAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Execute();
            Console.ReadLine();
        }

        public static async void Execute()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7014");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage httpresponse = await client.GetAsync("api/stud/getall");
                if (!httpresponse.IsSuccessStatusCode) Console.Error.WriteLine($"Erreur : {httpresponse.ReasonPhrase}");

                var students = await httpresponse.Content.ReadFromJsonAsync<List<Student>>();
                Console.WriteLine($"Get : {students.Count} résultat{(students.Count > 1 ? "s" : string.Empty)}");

                httpresponse = await client.PostAsync("api/stud/new", JsonContent.Create(new Student()
                {
                    MeanGrade = 5,
                    Name = "Albin"
                }));
                if (!httpresponse.IsSuccessStatusCode) Console.Error.WriteLine($"Erreur : {httpresponse.ReasonPhrase}");
                Console.WriteLine($"Nouvel étudiant inséré");
                Console.WriteLine($"Nouvelle tentative de Get");

                httpresponse = await client.GetAsync("api/stud/getall");
                if (!httpresponse.IsSuccessStatusCode) Console.Error.WriteLine($"Erreur : {httpresponse.ReasonPhrase}");

                students = await httpresponse.Content.ReadFromJsonAsync<List<Student>>();
                Console.WriteLine($"Get : {students.Count} résultat{(students.Count > 1 ? "s" : string.Empty)}");
            }
        }
    }
}