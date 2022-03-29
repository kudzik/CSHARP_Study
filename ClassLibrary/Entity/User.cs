﻿namespace ClassLibrary.Entity
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }

        public int PostCount { get; set; }
    }


}


