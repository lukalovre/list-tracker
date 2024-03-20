using Repositories;

namespace AvaloniaApplication1.ViewModels;

public partial class GamesViewModel(IDatasource datasource) : ItemViewModel<Game, GameGridItem, GameItem>(datasource)
{
    public override GameGridItem Convert(int index, Game i)
    {
        var year = HtmlHelper.GetYear(i.release_date);

        return new GameGridItem(i.ID, index + 1, i.game, year);
    }
}
