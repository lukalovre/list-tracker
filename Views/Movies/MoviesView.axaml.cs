using Avalonia.Controls;

namespace ListTracker.Views;

public partial class MoviesView : UserControl
{
    public MoviesView()
    {
        Resources.Add("TimeToStringConverter", new TimeToStringConverter());
        Resources.Add("DateTimeToStringConverter", new DateTimeToStringConverter());
        InitializeComponent();
    }
}
