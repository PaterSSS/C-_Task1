using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Task1Final.Models;

namespace Task1Final.ViewModels;

public partial class LibraryBookViewModel : ViewModelBase
{
    private LibraryBook _book;

    public LibraryBookViewModel()
    {
        // Инициализация начальной книги
        CreateNewBook(
            "001",
            "War and Peace",
            new List<string> { "Lev Tolstoy" },
            2124,
            "Fiction",
            BookState.UnderRestoration
        );
    }

    [ObservableProperty]
    private string _newTitle = string.Empty;

    [ObservableProperty]
    private string _newInventoryCode = string.Empty;

    [ObservableProperty]
    private string _newAuthorsInput = string.Empty;

    [ObservableProperty]
    private int? _newPages;

    [ObservableProperty]
    private string _newSection = string.Empty;

    [ObservableProperty]
    private BookState _newState = BookState.InStock;

    public string Title => _book.Title;
    public string InventoryCode => _book.InventoryCode;
    public List<string> Authors => _book.Authors;
    public int Pages => _book.Pages;
    public string Section => _book.Section;
    
    [ObservableProperty]
    private BookState _currentState;

    [RelayCommand]
    private void CreateNewBook()
    {
        var authors = NewAuthorsInput.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                           .Select(a => a.Trim())
                           .ToList();

        CreateNewBook(
            NewInventoryCode,
            NewTitle,
            authors,
            NewPages ?? 0,
            NewSection,
            NewState
        );
    }

    private void CreateNewBook(
        string inventoryCode,
        string title,
        List<string> authors,
        int pages,
        string section,
        BookState state)
    {
        _book = new LibraryBook(
            inventoryCode,
            title,
            authors,
            pages,
            section,
            state
        );

        // Обновляем все свойства
        OnPropertyChanged(nameof(Title));
        OnPropertyChanged(nameof(InventoryCode));
        OnPropertyChanged(nameof(Authors));
        OnPropertyChanged(nameof(Pages));
        OnPropertyChanged(nameof(Section));
        CurrentState = _book.CurrentState;

        // Сбрасываем поля ввода
        NewTitle = string.Empty;
        NewInventoryCode = string.Empty;
        NewAuthorsInput = string.Empty;
        NewPages = null;
        NewSection = string.Empty;
        NewState = BookState.InStock;
    }

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