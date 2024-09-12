using System.Collections.Generic;
using Repositories;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System.Linq;
using Controller;
using System.Drawing;

namespace AvaloniaApplication1.ViewModels;

public partial class StatsViewModel : ViewModelBase
{
    public List<Axis> _1001XAxes { get; set; } = [];
    public List<ISeries> _1001 { get; } = [];

    public StatsViewModel(IDatasource datasource)
    {

        var _1001_ = new _1001(datasource);

        var values = new List<ValuePoint>
        {
            new(){
                Label = "Music",
                Value = _1001_.Music,
                Color = ChartColors.GetColor("Music")
            },
            new(){
                Label = "Games",
                Value = _1001_.Games,
                Color = ChartColors.GetColor("Games")
            },
            new(){
                Label = "Paintings",
                Value = _1001_.Paintings,
                Color = ChartColors.GetColor("Paintings")
            },
            new(){
                Label = "Photographs",
                Value = _1001_.Photographs,
                Color = ChartColors.GetColor("Photographs")
            },
            new(){
                Label = "Songs",
                Value = _1001_.Songs,
                Color = ChartColors.GetColor("Songs")
            },
            new(){
                Label = "Books",
                Value = _1001_.Books,
                Color = ChartColors.GetColor("Books")
            },
            new(){
                Label = "Comics",
                Value = _1001_.Comics,
                Color = ChartColors.GetColor("Comics")
            },
            new(){
                Label = "Movies",
                Value = _1001_.Movies,
                Color = ChartColors.GetColor("Movies")
            },
            new(){
                Label = "TVShows",
                Value = _1001_.TVShows,
                Color = ChartColors.GetColor("TVShows")
            }
        };

        values = values.OrderBy(o => o.Value).ToList();

        var color = ChartColors.GetColor("All");

        _1001XAxes.Add(
            new Axis
            {
                Labels = values.Select(o => o.Label).ToList(),
                LabelsRotation = 0,
                SeparatorsPaint = new SolidColorPaint(new SKColor(200, 200, 200)),
                SeparatorsAtCenter = false,
                TicksPaint = new SolidColorPaint(new SKColor(35, 35, 35)),
                TicksAtCenter = true
            });

        _1001.Add(
            new ColumnSeries<int>
            {
                Values = values.Select(o => o.Value),
                Fill = new SolidColorPaint(new SKColor(color.R, color.G, color.B))
            });
    }

    public class ValuePoint
    {
        public string Label { get; set; }
        public int Value { get; set; }
        public Color Color { get; set; }
    }
}
