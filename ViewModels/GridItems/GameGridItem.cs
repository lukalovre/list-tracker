using AvaloniaApplication1.Models;

public record GameGridItem(int ID, int Index, string Title, int Year) : IGridItem;
