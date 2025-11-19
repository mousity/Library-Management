using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSA.OOP.LibraryManagementSystem;

internal class BooksController
{

    internal void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of books:[/]");

        foreach (var book in MockDatabase.Books)
        {
            AnsiConsole.MarkupLine($"[cyan]{book}[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue...");
    }

    internal void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of a book to add:");

        if (MockDatabase.Books.Contains(title))
        {
            AnsiConsole.MarkupLine("[red]This book is already on your list![/]");
        }
        else
        {
			MockDatabase.Books.Add(title);
            AnsiConsole.MarkupLine("[green]Your book has been added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
    }

    internal void DeleteBook()
    {
        if (MockDatabase.Books.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]No books available to delete.[/]");
            Console.ReadKey();
            return;
        }

        var bookToDelete = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("Select a [red]book[/] to delete:")
                            .AddChoices(MockDatabase.Books)
                            );

        if (MockDatabase.Books.Remove(bookToDelete))
        {
            AnsiConsole.MarkupLine("[red]Book deleted successfully![/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]Book not found.[/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
    }
}
