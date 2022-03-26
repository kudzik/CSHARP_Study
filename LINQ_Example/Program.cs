using System.Runtime.CompilerServices;
using ClassLibrary.Repository;
using ClassLibrary.ViewModel;

PersonViewModel pvm = new PersonViewModel();

// decyzja o użyciu składni SQL lub funkcji
pvm.SqlSyntax = true;



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

// Pobieranie i filtrowanie danych za pomocą Where
// pvm.WhereExpression();
// pvm.WhereExpressionMoreCondition();

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

var res = UserRepository.GetAllUser();
Console.WriteLine();
// wyświeltenie wyników
//foreach (var item in pvm.Persons)
//{
//    Console.WriteLine(item.ToString());
//}


