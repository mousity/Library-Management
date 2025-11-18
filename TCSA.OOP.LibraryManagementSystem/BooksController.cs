using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSA.OOP.LibraryManagementSystem;

internal static class BooksController
{
    private static List<string> books = new();

    internal static void ViewBooks()
    {
        AnsiConsole.MarkupLine("[yellow]List of books:[/]");

        foreach (var book in books)
        {
            AnsiConsole.MarkupLine($"[cyan]{book}[/]");
        }

        AnsiConsole.MarkupLine("Press any key to continue...");
    }

    internal static void AddBook()
    {
        var title = AnsiConsole.Ask<string>("Enter the [green]title[/] of a book to add:");

        if (books.Contains(title))
        {
            AnsiConsole.MarkupLine("[red]This book is already on your list![/]");
        }
        else
        {
            books.Add(title);
            AnsiConsole.MarkupLine("[green]Your book has been added successfully![/]");
        }

        AnsiConsole.MarkupLine("Press Any Key to Continue.");
    }

    internal static void DeleteBook()
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
}
