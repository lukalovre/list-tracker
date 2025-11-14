using Avalonia.Controls;

namespace ListTracker.Views;

public partial class GamesView : UserControl
{
    public GamesView()
    {
        Resources.Add("TimeToStringConverter", new TimeToStringConverter());
        Resources.Add("DateTimeToStringConverter", new DateTimeToStringConverter());
        InitializeComponent();
    }
}
