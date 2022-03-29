using ClassLibrary.Entity;
using Newtonsoft.Json;


namespace ClassLibrary.Repository
{
    public class UserRepository
    {
        private static string path = @"C:\Users\kudzi\source\repos\CSharp_Study\ClassLibrary\Repository\Users.json";

        public List<User> GetAll()
        {
            if (File.Exists(path))
            {
                var file = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<List<User>>(file);
                return json;
            }

            return null;
        }
    }
}
