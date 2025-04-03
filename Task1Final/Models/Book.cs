using System.Collections.Generic;

namespace Task1Final.Models;


public class LibraryBook
{
    public string InventoryCode { get; private set; }
    public string Title { get;  }
    public List<string> Authors { get;  }
    public int Pages { get;  }
    public string Section { get;  }
    public BookState CurrentState { get; private set; }

    public LibraryBook(string inventoryCode, string title, List<string> authors, int pages, string section, BookState initialState)
    {
        InventoryCode = inventoryCode;
        Title = title;
        Authors = authors;
        Pages = pages;
        Section = section;
        CurrentState = initialState;
    }

    public void ChangeState(BookState newState)
    {
        CurrentState = newState;
    }

    public void ChangeInventoryCode(string newCode)
    {
        InventoryCode = newCode;
    }
}
