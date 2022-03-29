using System.Runtime.CompilerServices;
using System.Text.Json;
using ClassLibrary.Entity;
using ClassLibrary.Entity.Students;
using ClassLibrary.Repository;
using ClassLibrary.ViewModel;

var students = Student.GetStudents();
var teachers = Teacher.GetAllTeachers();
var numbers1 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var numbers2 = new[] { 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
var numbers3 = new[] { 1, 2, 2, 4, 4, 5, 6, 7, 4, 2, 0 };

// # Sortowanie danych

var sortedStudentsQ = (from student in students orderby student.First select student);
var sortedTeachersF = students.OrderBy(s => s.First).Select(s => s);

var sortedStudentsDesQ = from student in students
                         orderby student.First descending
                         select student;

var sortedTeachersDesF = students.OrderByDescending(s => s.First).Select(s => s);

// Sortowanie po wielu polach
var sortedStudentManyFieldsQ = from student in students
                               orderby student.First, student.Last
                               select student;

var sortedStudentManyFieldsF = students.OrderBy(s => s.First).ThenBy(s => s.Last).Select(s => s);
// Sortowanie po długości imienia

var sortedStudentNameLengthFieldsQ = from student in students
                                     orderby student.First.Length // `descending` jeśli chcemy malejąco 
                                     let firstLength = student.First.Count()
                                     select student;

var sortedStudentNameLengthFieldsF = students.OrderBy(s => s.First.Length).Select(s => s);

var sortedStudentNameLengthFieldsDescF = students.OrderByDescending(s => s.First.Length).Select(s => s);

//foreach (var item in sortedStudentNameLengthFieldsQ)
//{
//    Console.WriteLine($"Length: {item.First.Length} {item.First}");
//}


// # Operacje na zestawach

// Distinct
// Zwraca unikalne wartości z kolekcji
var distinctNumbers = numbers3.Distinct();

// Zwraca unikalne wartości z możliwością zaznaczenia właściwości
//foreach (var item in students.DistinctBy(s => s.Last))
//{
//    Console.WriteLine($"Last Name: {item.Last}");

//}

// Expect
// Unikalne dnae dla zbioru piewszego
var expectNumbers2 = numbers1.Except(numbers2);

//foreach (var item in expectNumbers2) 
//    Console.WriteLine(item); // 1, 2, 3, 4

// Intersect
// Elementy wspólne dla podanych zbiorów

var intersectNumbers = numbers1.Intersect(numbers2);

//foreach (var item in intersectNumbers)
//    Console.WriteLine(item); // 5, 6, 7, 8, 9, 10

// Union
var unionNumbers = from number in numbers1.Union(numbers2)
                   select number;

//foreach (var item in unionNumbers)
//    Console.WriteLine(item);

// # Filtrowanie wyników

// Składnia zapytania
var studentsFirstNameStartWithLQ = from student in students
                                   where student.First.StartsWith("S")
                                   select student;

// Składnia funkcyjna
var studentsFirstNameStartWithLF = students.Where(s => s.First.StartsWith("S")).Select(s => s);

//foreach (var item in studentsFirstNameStartWithLF)
//    Console.WriteLine($"Studenci których imię zaczyna się na S: {item.First}");

// Odwołanie do elementu w liście lub tablicy
var studentQueryScores = from student in students
                         where student.Scores[0] > 90 && student.Scores[^1] < 80 // filtrowanie
                         orderby student.Scores[0] descending // sortowanie
                         select student;

//Console.WriteLine(@$"Studenci których pierwszy wynik testu jest większy niż 90 a ostatni mniejszy od 80:");
//foreach (var item in studentQueryScores)
//    Console.WriteLine(item.First);

// # Kwantyfikatory

var allScore = from student in students
               where student.Scores.All(s=>s > 60)
               select student;

Console.WriteLine("\nAll");
foreach (var item in allScore)
    Console.WriteLine(item.First);


var anyScore = from student in students
               where student.Scores.Any(s => s == 90)
               select student;
Console.WriteLine("\nAny");
foreach (var item in anyScore)
    Console.WriteLine(item.First);

var containsFirst = from student in students
                    where student.First.Contains("la")
                    select student;
Console.WriteLine("\nContains");
foreach (var item in containsFirst)
    Console.WriteLine(item.First);

PersonViewModel pvm = new PersonViewModel();


// decyzja o użyciu składni SQL lub funkcji
//pvm.SqlSyntax = true;



//// pobieranie wszystkich rekordów i dodanie ich do listy
//pvm.GetAllAndAddToList();

//// pobranie wszystkich rekordów
// pvm.GetAll();

//// Pobranie pojedynczej kolumny
// pvm.SelectSpecificColumn();

// Pobranie kilku kolumn z zastosowaniem nowego obiektu, zwracany jest nadal obiekt klasy Person, pola które nie zostały wybrane będą miały wartości domyślne
// pvm.GetSpecificColumns();

// Pobieranie określonych kolumn z zastosowaniem nowej klasy anonimowej, pozwala nam stworyć nowe obiekty zawierające pola wybrane i przepisane.
// pvm.AnonymousClass();

// Sortowanie danych
// pvm.OrderByOne();

// Sortowanie danych malejąco
// pvm.OrderByDescending();

// Sortowanie po wielu polach
// pvm.OrderByTwoFields();

// własna metoda rozszeżająca LINQ
// pvm.PersonLinqHelperByCountryCode();

// Pobieranie wyników
// Jeśli nie znajdzie żadnego rekordu zostanie rzucony wyjątek  InvalidOperationException, jeśli znajdzie wiele wyników zwróci pierwszy.
// pvm.First();

// Jeśli nie znajdzie żadnego rekordu zostanie zwrócone null, jeśli znajdzie wiele wyników zwróci pierwszy.
// pvm.FirstOrDefault();

// Ostatni element lub wyjątek
//pvm.Last();

// Ostatni element lub null
//pvm.LastOrDefault();

// Single lub SingleOrDefault stosujemy wtedy gdy spodziewamy się tylko jednego elementu np. Id rekordu w bazie danych
// pvm.ForEachOperation();

//var res = userModel.ChainQuery();

//var take = userModel.TakeElement(3);
//var skip = userModel.SkipElement(3);

//int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//int[] numbers2 = { 9, 10, 11, 12, 13, 14 };
//var concat = numbers.Concat(numbers2);
//var union = numbers.Union(numbers2);
//var intersect = numbers.Intersect(numbers2);
//var except = numbers.Except(numbers2);

UserRepository userRepository = new UserRepository();
var users = userRepository.GetAll();

PersonRepository personRepository = new PersonRepository();
var Persons = personRepository.GetAllPerson();

TodoRepository todoRepository = new TodoRepository();
var Todos = todoRepository.GetAllTodo();

// Lączenie kolekcji po wspólnym kluczu

//var res = from person in Persons
//          join todo in Todos on person.Id equals todo.UserId
//          select new { PersonId = person.Id, Todotitle = todo.Title };

//foreach (var item in res)
//{
//    Console.WriteLine(item.PersonId + ": " + item.Todotitle);
//}


//// Łączenie dwóch kolekcji


//var peopleInSeattle = (from student in students
//                       where student.City == "Seattle"
//                       select student.Last)
//                   .Concat(from teacher in teachers
//                           where teacher.City == "Seattle"
//                           select teacher.Last);

//Console.WriteLine("Studenci i nauszyciele mieszkający w Seattle:");

//// Wykonanie zapytania poprzez iterację
//foreach (var person in peopleInSeattle)
//{
//    Console.WriteLine(person);
//}

//// Filtrowanie
//var studentQueryScores = from student in students
//                         where student.Scores[0] > 90 && student.Scores[^1] < 80
//                         orderby student.Scores[0] descending
//                         select student;

//foreach (var item in studentQueryScores)
//{
//    Console.WriteLine($"Student name: {item.First}, First score greater that 90 -> First: {item.Scores[0]} last: {item.Scores[^1]}");
//}

//// Grupowanie i wyświetlanie danych

//var gropStudentsByLastName = from student in students
//                             group student by student.Last[0] into studentGroup
//                             orderby studentGroup.Key
//                             select studentGroup;

//foreach (var item in gropStudentsByLastName)
//{
//    Console.WriteLine(item.Key);
//    foreach (var itemStudent in item)
//    {
//        Console.WriteLine(itemStudent.Last);
//    }
//}

// zmienna let

var studentQuery5 =
    from student in students
    let totalScore = student.Scores[0] + student.Scores[1] +
        student.Scores[2] + student.Scores[3]
    where totalScore / 4 < student.Scores[0]
    select student.Last + " " + student.First;

foreach (string s in studentQuery5)
{
    Console.WriteLine(s);
}


//// Grupowanie z dotatkową zmienną
//var groupResult = from person in Persons
//                  group person by person.Country into myGroup
//                  where myGroup.Count() > 4
//                  select myGroup;

//foreach (var item in groupResult)
//{
//    Console.WriteLine();
//    Console.WriteLine(item.Key);
//    foreach (var s in item)
//    {
//        var res = item.Select(p => p.FirstName);
//        Console.Write(s.FirstName + " ");
//    }
//}

Console.WriteLine();
// wyświeltenie wyników
//foreach (var item in pvm.Persons)
//{
//    Console.WriteLine(item.ToString());
//}


