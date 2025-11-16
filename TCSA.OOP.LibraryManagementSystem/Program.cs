
using System.Diagnostics;
using Spectre.Console;

var menuChoices = new string[3] { "View Books", "Add Book", "Delete Book" };
var books = new List<string>()
{
    "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
};

while (true)
{
    Console.Clear();

    var choice = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOption>()
        .Title("What do you want to do next?")
        .AddChoices(Enum.GetValues<MenuOption>()));

    switch (choice)
    {
        case MenuOption.ViewBooks:
            ViewBooks();
            break;
        case MenuOption.AddBook:
            AddBook();
            break;
        case MenuOption.DeleteBook:
            DeleteBook();
            break;
    }
    Console.ReadLine();
    
}

void ViewBooks()
{
    AnsiConsole.MarkupLine("[yellow]List of books:[/]");

            foreach(var book in books)
            {
                AnsiConsole.MarkupLine($"[cyan]{book}[/]");
            }

            AnsiConsole.MarkupLine("Press any key to continue...");
}

void AddBook()
{
    var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of a book to add:");

            if (books.Contains(title))
            {
                AnsiConsole.MarkupLine("[red]This book is already on your list![/]");
            } else
            {
                books.Add(title);
                AnsiConsole.MarkupLine("[green]Your book has been added successfully![/]");
            }

            AnsiConsole.MarkupLine("Press Any Key to Continue.");
}

void DeleteBook()
{
    if (books.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
                Console.ReadKey();
                return;
            }

            var bookToDelete = AnsiConsole.Prompt(
                                new SelectionPrompt<string>()
                                .Title("Select a [red]book[/] to delete:")
                                .AddChoices(books)
                                );

            if (books.Remove(bookToDelete))
            {
                AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Book not found.[/]");
            }

            AnsiConsole.MarkupLine("Press Any Key to Continue.");
}

enum MenuOption
{
    ViewBooks,
    AddBook,
    DeleteBook
}