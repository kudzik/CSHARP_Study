using ClassLibrary.Entity;
using Newtonsoft.Json;


namespace ClassLibrary.Repository
{
    public class PersonRepository
    {
        private static string path = @"C:\Users\kudzi\source\repos\CSharp_Study\ClassLibrary\Repository\Persons.json";


        public static List<Person>? GetAllPerson()
        {
            if (File.Exists(path))
            {
                var file = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<List<Person>>(file);
                return json;
            }

            return null;
        }


    }
}
