Projekt akademicki aplikacji webowej, mający na celu zaprezentowanie usług platformy Azure. 
Jest to aplikacja do tworzenia listy rzeczy do zrobienia, tzn listy Todo.
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
