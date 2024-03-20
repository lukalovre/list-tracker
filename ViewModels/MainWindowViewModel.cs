using Repositories;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MoviesViewModel MoviesViewModel { get; } = new MoviesViewModel(new CsvDatasource());
    public GamesViewModel GamesViewModel { get; } = new GamesViewModel(new CsvDatasource());
    public TVShowsViewModel TVShowsViewModel { get; } = new TVShowsViewModel(new CsvDatasource());

    public MainWindowViewModel()
    {
    }
}
