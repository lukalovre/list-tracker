using Repositories;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private static IDatasource _datasource;

    public MoviesViewModel MoviesViewModel { get; } = new MoviesViewModel(_datasource);
    public GamesViewModel GamesViewModel { get; } = new GamesViewModel(_datasource);
    public TVShowsViewModel TVShowsViewModel { get; } = new TVShowsViewModel(_datasource);
    public StatsViewModel StatsViewModel { get; } = new StatsViewModel(_datasource);

    public MainWindowViewModel(IDatasource datasource)
    {
        _datasource = datasource;
    }
}
