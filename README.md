Projekt akademicki aplikacji webowej, mający na celu zaprezentowanie usług platformy Azure. 
Jest to aplikacja do tworzenia listy rzeczy do zrobienia, tzn listy Todo. Umożliwia tworzenie nowych elementów listy, edytowanie, przeglądanie, odznaczanie oraz usuwanie. Wszystkie elementy przechowywane są przy użyciu usługi Azure Cosmos DB.
Stos technologiczny:
1) Aplikacja - ASP.NET Core MVC
2) Platforma Azure - Azure Cosmos DB, Azure App Service
3) Setup - Powershell, Microsoft Visual Studio 2019

Wymagania wstępne: 
1) Zaktualizowany wiersz poleceń powershell
2) Microsoft Visual Studio 2019 PREVIEW (ważne, by była to wersja 2019 preview, gdyż wspiera najnowszą wersję .net framework 5.0 wraz z pakietem technologii webowych)
3) środowisko kontroli wersji git

Setup: 
Instalacja aplikacji została podzielona na dwa etapy: 
1) skryptowy - w nim przygotowane skrypty powershell przygotowują platformę azure do pracy z aplikacją
2) visual studio - w nim następuje zbudowanie aplikacji oraz jej upublicznienie

Przebieg instalacji:

0. Na początek instalacja wymaga ściągnięcia zawartości repozytorium.
1. Należy uruchomić konsolę powershell wraz z prawami administratora.
2. Kolejnym krokiem jest uruchomienie skryptu ".\TodoList\TodoList.App\Scripts\setup.ps1"
3. Podczas wykonywania skryptu należy zaakceptować dodawanie do konsoli nowych modułów poprzez przycisk y potwierdzony enterem, oraz zalogować się swoimi danymi na platformie Azure.
4. Następnym etapem jest otwarcie aplikacji (plik solucji ".\TodoList\TodoList.sln") przy użyciu Microsoft Visual Studio 2019 Preview
5. Aplikację należy zbudować poprzez wybór menu kontekstowego Build -> Build Solution.
6. Należy kliknąć prawym przyciskiem myszy na projekcie TodoList.App w drzewie solucji i wybrać opcję Publish...
7. Kolejno trzeba wybrać: Target -> Azure -> Next 
8. Dalej: Specific target -> Azure App Service (Windows) -> Next
9. Następnie trzeba wybrać utworzoną przez skrypt instancję App Service "mytodoappwebappname" -> Finish
12. Z powodu użycia najnowszej wersji .net frameworku, należy zmienić Deployment Mode z "Framework-Dependent" na "Self-Contained" poprzez kliknięcie ikony ołówka i wybraniu odpowiedniej opcji w zakładce Settings -> Deployment Mode oraz zaakceptowaniu poprzez przycisk Save.
11. Ostatnim krokiem jest zaakceptowanie publikacji przyciskiem Publish.

Przykładowe użycie:

a) Aby utworzyć nowy element Todo listy, należy kliknąć przycisk "Create New", podać Name i Description, a na koniec zaakceptować przyciskiem Create.
b) W celu kolejno edycji, obejżenia szczegółów lub usunięcia elementu, należy wybrać odpowiednią opcję znajdującą się na końcu wiersza danego elementu.
