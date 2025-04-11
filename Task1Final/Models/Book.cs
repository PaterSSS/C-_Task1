using System.Collections.Generic;

namespace Task1Final.Models;


public class LibraryBook(
    string inventoryCode,
    string title,
    List<string> authors,
    int pages,
    string section,
    BookState initialState)
{
    public string InventoryCode { get; private set; } = inventoryCode;
    public string Title { get;  } = title;
    public List<string> Authors { get;  } = authors;
    public int Pages { get;  } = pages;
    public string Section { get;  } = section;
    public BookState CurrentState { get; private set; } = initialState;

    public void ChangeState(BookState newState)
    {
        CurrentState = newState;
    }

    public void ChangeInventoryCode(string newCode)
    {
        InventoryCode = newCode;
    }
}
