using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1Final.Models;

public enum BookState
{
    InStock,
    Issued,
    UnderRestoration
    
}

public static class BookStateInfo
{
    public static IEnumerable<BookState> AllStates => 
        Enum.GetValues(typeof(BookState)).Cast<BookState>();
}
