using ClassLibrary.Entity;

namespace LINQ_Example.LinqHelpers;

public static class PersonLinqHelper
{
    public static IEnumerable<Person> ByCountryCode(this IEnumerable<Person> query, string coutntyCode)
    {
        return query.Where(person => person.CountryCode == coutntyCode);    
    }
}