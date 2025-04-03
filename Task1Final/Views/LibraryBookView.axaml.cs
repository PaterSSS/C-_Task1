using Avalonia.Controls;

namespace Task1Final.Views;

using Avalonia.Controls;
using Avalonia.Markup.Xaml;

public partial class LibraryBookView : UserControl
{
    public LibraryBookView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}
