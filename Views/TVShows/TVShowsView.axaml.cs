using Avalonia.Controls;

namespace ListTracker.Views;

public partial class TVShowsView : UserControl
{
    public TVShowsView()
    {
        Resources.Add("TimeToStringConverter", new TimeToStringConverter());
        Resources.Add("DateTimeToStringConverter", new DateTimeToStringConverter());
        InitializeComponent();
    }
}
