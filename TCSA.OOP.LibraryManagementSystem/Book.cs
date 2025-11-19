using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSA.OOP.LibraryManagementSystem;

internal class Book
{
    public string Name { get; set; } = "Default Name";
    public int Pages { get; set; } = 100;

    internal Book()
    {
        Name = "Unknown";
        Pages = 0;
    }

    internal Book(int pages)
    {
        Name = "Unknown";
        Pages = pages;
        Console.WriteLine($"Name: {Name}, Pages = {Pages}");
    }

    internal Book(string name, int pages)
    {
        Name = name;
        Pages = pages;
        Console.WriteLine($"Name: {Name}, Pages = {Pages}");
    }
}
