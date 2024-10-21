using AvaloniaApplication1.Models;

public record MovieGridItem(string ID, int Index, string Title, string Director, int Year, int Runtime, int NumVotes) : IGridItem;

public record TVShowGridItem(string ID, int Index, string Title, string Director, int Year, int Runtime, int NumVotes) : IGridItem;

public record GameGridItem(string ID, int Index, string Title, int Year, string Developer, string Platform, string URL) : IGridItem;
