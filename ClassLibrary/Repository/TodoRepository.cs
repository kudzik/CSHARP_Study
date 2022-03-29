using ClassLibrary.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public class TodoRepository
    {
        private static string path = @"C:\Users\kudzi\source\repos\CSharp_Study\ClassLibrary\Repository\Todos.json";

        public  List<Todo> GetAllTodo()
        {
            if (File.Exists(path))
            {
                var file = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<List<Todo>>(file);
                return json;
            }

            return null;
        }
    }
}
