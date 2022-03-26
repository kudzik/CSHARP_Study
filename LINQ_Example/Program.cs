using ClassLibrary.ViewModel;

PersonViewModel pvm = new PersonViewModel();

// decyzja o użyciu składni SQL lub funkcji
pvm.SqlSyntax = false;



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
pvm.WhereExpression();

// wyświeltenie wyników
foreach (var item in pvm.Persons)
{
    Console.WriteLine(item.ToString());
}


