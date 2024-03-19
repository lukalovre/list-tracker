using AvaloniaApplication1.Repositories;
using Repositories;

namespace AvaloniaApplication1.ViewModels;

public partial class TVShowsViewModel(IDatasource datasource, IExternal<TVShow> external)
: ItemViewModel<TVShow, TVShowGridItem, MovieItem>(datasource, external)
{
    public override TVShowGridItem Convert(int index, TVShow i)
    {
        return new TVShowGridItem(
            i.ID,
            index + 1,
            i.Title,
            0);
    }
}
