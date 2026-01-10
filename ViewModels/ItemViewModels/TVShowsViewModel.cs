using Repositories;

namespace ListTracker.ViewModels;

public partial class TVShowsViewModel(IDatasource datasource) 
: ItemViewModel<TVShow, TVShowGridItem, TVShowItem>(datasource)
{
    public override TVShowGridItem Convert(int index, TVShow i)
    {
        return new TVShowGridItem(
            i.ExternalID,
            index + 1,
            i.Title,
            i.Director,
            i.Year ?? 0,
            i.Runtime ?? 0,
            i.NumVotes ?? 0);
    }
}
