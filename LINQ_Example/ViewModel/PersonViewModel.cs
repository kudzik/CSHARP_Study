using System.Net.Http.Headers;
using System.Text;
using ClassLibrary.Entity;
using ClassLibrary.Repository;
using LINQ_Example.LinqHelpers;


namespace ClassLibrary.ViewModel;

public class PersonViewModel
{
    public List<Person>? Persons { get; set; }
    public bool SqlSyntax { get; set; }
    public string? TextResult { get; set; }

    // Pobieranie wszystkich rekordów i dodanie ich do listy
    public void GetAllAndAddToList()
    {
        var listPersons = new List<Person>();

        foreach (var item in Persons)
        {
            listPersons.Add(item);
        }

        TextResult = $"Total Persons: {listPersons.Count}";
    }


    public void GetAll()
    {
        if (SqlSyntax)
        {
            // Składnia SQL
            Persons = (from person in Persons select person).ToList();
        }
        else
        {
            // składnia funkcyjna
            Persons = Persons?.Select(p => p).ToList();
        }
    }

    public void SelectSpecificColumn()
    {
        var sb = new StringBuilder();
        List<string> list = new List<string>();

        if (SqlSyntax)
        {
            list.AddRange(from p in Persons select p.FirstName);
        }
        else
        {
            if (Persons != null) list.AddRange(Persons.Select(p => p.FirstName)!);
        }

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

    }
    public void GetSpecificColumns()
    {
        if (SqlSyntax)
        {
            Persons = (from person in Persons select new Person() { FirstName = person.FirstName }).ToList();
        }
        else
        {
            Persons = Persons.Select(person => new Person() { FirstName = person.FirstName }).ToList();
        }
    }

    public void AnonymousClass()
    {
        if (SqlSyntax)
        {
            var newAnonymousObject =
                (from person in Persons select new { Imie = person.FirstName, Nazwisko = person.LastName });

            foreach (var item in newAnonymousObject)
            {
                Console.WriteLine($"Imie: {item.Imie}, Nazwisko: {item.Nazwisko}");
            }
        }
        else
        {
            var newAnonymousObject = Persons.Select(person => new { Imie = person.FirstName, Nazwisko = person.LastName });

            foreach (var item in newAnonymousObject)
            {
                Console.WriteLine($"Imie: {item.Imie}, Nazwisko: {item.Nazwisko}");
            }
        }
    }

    public void OrderByOne()
    {
        if (SqlSyntax)
        {
            Persons = (from person in Persons orderby person.FirstName select person).ToList();
        }
        else
        {
            Persons = Persons.Select(person => person).OrderBy(person => person.FirstName).ToList();
        }
    }

    public void OrderByDescending()
    {
        if (SqlSyntax)
        {
            Persons = (from person in Persons orderby person.FirstName descending select person).ToList();
        }
        else
        {
            Persons = Persons.Select(person => person).OrderByDescending(person => person.FirstName).ToList();
        }
    }

    public void OrderByTwoFields()
    {
        if (SqlSyntax)
        {
            Persons = (from person in Persons orderby person.FirstName, person.LastName select person).ToList();
        }
        else
        {
            Persons = Persons.Select(person => person).OrderBy(person => person.FirstName)
                .ThenBy(person => person.LastName).ToList();
        }
    }

    public void WhereExpression()
    {
        if (SqlSyntax)
        {
            Persons = (from person in Persons where person.CountryCode == "PL" select person).ToList();
        }
        else
        {
            Persons = Persons.Where(person => person.CountryCode == "PL").Select(person => person).ToList();
        }
    }

    public void WhereExpressionMoreCondition()
    {
        if (SqlSyntax)
        {
            Persons = (from person in Persons where person.CountryCode == "PL" && person.Email.EndsWith("pl") select person).ToList();
        }
        else
        {
            Persons = Persons.Where(person => person.CountryCode == "PL" && person.Email.EndsWith("pl")).Select(person => person).ToList();
        }
    }

    public void PersonLinqHelperByCountryCode()
    {

        // własne rozszeżenie LINQ `ByCountryCode`

        if (SqlSyntax)
        {
            Persons = (from person in Persons select person).ByCountryCode("PL").ToList();

        }
        else
        {
            Persons = Persons.Select(person => person).ByCountryCode("CN").ToList();
        }
    }


    public void First()
    {
        Person search;

        if (SqlSyntax)
        {
            search = (from person in Persons select person).First(person => person.CountryCode == "EN");
        }
        else
        {
            search = Persons.First(person => person.CountryCode == "EN");
        }

        TextResult = search.ToString();
    }

    public void FirstOrDefault()
    {
        Person search;

        if (SqlSyntax)
        {
            search = (from person in Persons select person).FirstOrDefault(person => person.CountryCode == "EN");
        }
        else
        {
            search = Persons.FirstOrDefault(person => person.CountryCode == "EN");
        }

        TextResult = search.ToString();
    }

    public void Last()
    {
        Person search;
        try
        {
            if (SqlSyntax)
            {
                search = (from person in Persons select person).Last(person => person.CountryCode == "PL");
            }
            else
            {
                search = Persons.Last(person => person.CountryCode == "EN");
            }

            TextResult = search.ToString();
        }
        catch (Exception)
        {
            TextResult = "Not Found";
        }
    }

    public void LastOrDefault()
    {
        Person search;

        if (SqlSyntax)
        {
            search = (from person in Persons select person).LastOrDefault(person => person.CountryCode == "EN");
        }
        else
        {
            search = Persons.LastOrDefault(person => person.CountryCode == "EN");
        }

        if (search is not null)
        {
            Console.WriteLine(search);
        }
        else
        {
            Console.WriteLine("Brak wyniku");
        }
    }

    public void ForEachOperation()
    {
        if (SqlSyntax)
        {
            Persons = (from person in Persons
                       let tmp = person.NameLength = person.FirstName.Length
                       select person
                       ).ToList();
        }
        else
        {
            Persons.ForEach(person => person.NameLength = person.FirstName.Length);
        }

        foreach (var item in Persons)
        {
            Console.WriteLine(item.NameLength);
        }
    }
}

