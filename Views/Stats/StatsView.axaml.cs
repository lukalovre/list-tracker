using Avalonia.Controls;

namespace ListTracker.Views;

public partial class StatsView : UserControl
{
    public StatsView()
    {
        Resources.Add("TimeToStringConverter", new TimeToStringConverter());
        Resources.Add("DateTimeToStringConverter", new DateTimeToStringConverter());
        InitializeComponent();
    }
}
