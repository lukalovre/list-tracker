using AvaloniaApplication1.Repositories;
using Repositories;

namespace AvaloniaApplication1.ViewModels;

public partial class GamesViewModel(IDatasource datasource, IExternal<Game> external)
: ItemViewModel<Game, GameGridItem, GameItem>(datasource, external)
{
    // private SortableBindingList<Game1001> GetGamesFromCsv(string listName)
    // {
    //     return new SortableBindingList<Game1001>(
    //         CsvHelper.GetFromList<IgdbListItem>(Paths.Igdb, listName, out _)
    //         .Where(o => !Datasource.GetList<Game>().Any(g => g.Igdb == o.id) && !Igdb.AlternativeVersions.Keys.Contains(o.id))
    //         .Select(o => Igdb.ConvertToGame1001(o))
    //         .ToList());
    // }

    public override GameGridItem Convert(int index, Game i)
    {
        return new GameGridItem(i.ID, index + 1, i.game, i.release_date);
    }
}
