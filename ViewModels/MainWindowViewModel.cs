using System.Collections.Generic;
using AvaloniaApplication1.Repositories;
using Repositories;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MoviesViewModel MoviesViewModel { get; } = new MoviesViewModel(new TsvDatasource(), new MovieExternal());
    public GamesViewModel GamesViewModel { get; } = new GamesViewModel(new TsvDatasource(), new GameExtetrnal());
    public TVShowsViewModel TVShowsViewModel { get; } = new TVShowsViewModel(new TsvDatasource(), new TVShowExternal());

    public MainWindowViewModel()
    {
    }
}
