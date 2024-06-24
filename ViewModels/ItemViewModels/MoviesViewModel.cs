using Repositories;

namespace AvaloniaApplication1.ViewModels;

public partial class MoviesViewModel(IDatasource datasource) : ItemViewModel<Movie, MovieGridItem, MovieItem>(datasource)
{
    public override MovieGridItem Convert(int index, Movie i)
    {
        return new MovieGridItem(
            i.ID,
            index + 1,
            i.Title,
            i.Director,
            i.Year ?? 0,
            i.Runtime ?? 0,
            i.NumVotes ?? 0);
    }
}
