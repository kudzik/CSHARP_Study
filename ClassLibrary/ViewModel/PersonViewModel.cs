using System.Net.Http.Headers;
using System.Text;
using ClassLibrary.Entity;
using ClassLibrary.Repository;

namespace ClassLibrary.ViewModel;

public class PersonViewModel
{
    public List<Person>? Persons { get; set; } = PersonRepository.GetAllPerson();
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

        //// Wypisanie wsystkich rekordów
        //foreach (var item in listPersons)
        //{
        //    Console.WriteLine(item.ToString());
        //}
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
                (from person in Persons select new {Imie = person.FirstName, Nazwisko = person.LastName});

            foreach (var item in newAnonymousObject)
            {
                Console.WriteLine($"Imie: {item.Imie}, Nazwisko: {item.Nazwisko}");
            }
        }
        else
        {
            var newAnonymousObject = Persons.Select(person=> new {Imie=person.FirstName, Nazwisko = person.LastName});

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
}

