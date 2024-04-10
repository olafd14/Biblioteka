Biblioteka - System Wypożyczania Książek
Projekt to aplikacja ASP.NET MVC, która umożliwia użytkownikom wypożyczanie książek z biblioteki. Użytkownicy mogą przeglądać dostępne książki, wypożyczać je, 
czytać recenzje innych użytkowników oraz oceniać książki. Ponadto aplikacja umożliwia zarządzanie kontami użytkowników, obsługę ról, dodawanie nowych książek i tworzenie kategorii.

Funkcje Aplikacji
Przeglądanie dostępnych książek w bibliotece.
Wypożyczanie książek (jedna książka na użytkownika).
Czytanie recenzji i ocenianie książek.
Rejestracja i logowanie użytkowników.
Zarządzanie kontami użytkowników oraz rolami (administrator, pracownik, klient).
Dodawanie nowych książek do kolekcji.
Tworzenie nowych kategorii książek.

Technologie
ASP.NET MVC
Entity Framework Core
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft SQL Server

System Logowania
Aplikacja wykorzystuje bibliotekę Microsoft.AspNetCore.Identity.EntityFrameworkCore do implementacji systemu uwierzytelniania i autoryzacji.
Biblioteka ta zapewnia gotowe narzędzia do zarządzania kontami użytkowników, w tym logowanie, rejestrację, resetowanie hasła oraz nadawanie ról.

Dzięki wykorzystaniu Microsoft.AspNetCore.Identity.EntityFrameworkCore aplikacja zapewnia standardowe mechanizmy bezpieczeństwa,
takie jak przechowywanie haseł w postaci zahaszowanej oraz możliwość łatwego zarządzania kontami użytkowników i ról.
