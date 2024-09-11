using Repositories;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel(IDatasource datasource) : ViewModelBase
{
    public MoviesViewModel MoviesViewModel { get; } = new MoviesViewModel(datasource);
    public GamesViewModel GamesViewModel { get; } = new GamesViewModel(datasource);
    public TVShowsViewModel TVShowsViewModel { get; } = new TVShowsViewModel(datasource);
    public StatsViewModel StatsViewModel { get; } = new StatsViewModel(datasource);
}
