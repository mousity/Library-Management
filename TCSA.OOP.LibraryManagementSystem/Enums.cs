using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSA.OOP.LibraryManagementSystem;

internal static class Enums
{
    internal enum MenuAction
    {
        ViewItem,
        AddItem,
        DeleteItem
    }

    internal enum ItemType
    {
        Book,
        Magazine,
        Newspaper
    }
}
