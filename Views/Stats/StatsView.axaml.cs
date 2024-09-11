using Avalonia.Controls;

namespace AvaloniaApplication1.Views;

public partial class StatsView : UserControl
{
    public StatsView()
    {
        Resources.Add("TimeToStringConverter", new TimeToStringConverter());
        Resources.Add("DateTimeToStringConverter", new DateTimeToStringConverter());
        InitializeComponent();
    }
}
