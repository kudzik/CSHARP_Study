using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Entity
{
    [Serializable]
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? IpAddress { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? CountryCode { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"ID: {Id} ");
            sb.Append($"FirstName: {FirstName} ");
            sb.Append($"LastName: {LastName} ");
            sb.Append($"Email: {Email} ");
            sb.Append($"Gender: {Gender} ");
            sb.Append($"IpAddress: {IpAddress} ");
            sb.Append($"City: {City} ");
            sb.Append($"Country: {Country} ");
            sb.Append($"CountryCode: {CountryCode} ");

            return sb.ToString();
        }
    }

}


