using System;
using System.Collections.Generic;
using System.Linq;
using AvaloniaApplication1.ViewModels.Extensions;
using Repositories;

namespace AvaloniaApplication1.ViewModels;

public partial class GamesViewModel(IDatasource datasource) : ItemViewModel<Game, GameGridItem, GameItem>(datasource)
{
    public override GameGridItem Convert(int index, Game i)
    {
        var year = HtmlHelper.GetYear(i.release_date);

        var developers = GetList(i.companies);
        var platforms = GetList(i.platforms);

        return new GameGridItem(
            i.ID,
            index + 1,
            i.game,
            year,
            developers?.FirstOrDefault() ?? string.Empty,
            platforms.FirstOrDefault() ?? string.Empty,
            i.url);
    }

    private List<string> GetList(string companies)
    {
        companies = companies.TrimStart("[").TrimEnd("]");
        var splitList = companies.Split(",");

        return splitList.Select(o => o.TrimStart("\"").TrimEnd("\"")).ToList();
    }
}
