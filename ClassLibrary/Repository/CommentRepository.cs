using ClassLibrary.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public class CommentRepository
    {
        private static string path = @"C:\Users\kudzi\source\repos\CSharp_Study\ClassLibrary\Repository\Comments.json";

        public static List<Comment>? GetAllComment()
        {
            if (File.Exists(path))
            {
                var file = File.ReadAllText(path);
                var json = JsonConvert.DeserializeObject<List<Comment>>(file);
                return json;
            }

            return null;
        }
    }
}
