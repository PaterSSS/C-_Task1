using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task1Final.Models;

namespace Task1Final.ViewModels;

public partial class LibraryBookViewModel : ViewModelBase
{
    private readonly LibraryBook _book;

    public LibraryBookViewModel()
    {
        _book = new LibraryBook(
            "001",
            "War and Peace",
            new List<string> { "Lev Tolstoyi" },
            2124,
            "Fiction",
            BookState.UnderRestoration
        );
        _currentState = _book.CurrentState;
    }

    public string Title => _book.Title;
    public string InventoryCode => _book.InventoryCode;
    public List<string> Authors => _book.Authors;
    public int Pages => _book.Pages;
    public string Section => _book.Section;

    [ObservableProperty]
    private BookState _currentState;

    [ObservableProperty]
    private string _newInventoryCode;

    [RelayCommand]
    private void ChangeState(BookState newState)
    {
        _book.ChangeState(newState);
        CurrentState = _book.CurrentState;
        
    }
    
    [RelayCommand]
    private void UpdateInventoryCode()
    {
        if (!string.IsNullOrWhiteSpace(NewInventoryCode))
        {
            _book.ChangeInventoryCode(NewInventoryCode);
            OnPropertyChanged(nameof(InventoryCode));
            NewInventoryCode = string.Empty;
        }
    }
}