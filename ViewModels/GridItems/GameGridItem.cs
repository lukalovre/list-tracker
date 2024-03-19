using AvaloniaApplication1.Models;

public record GameGridItem(int ID, int Index, string Title, string Year) : IGridItem;
