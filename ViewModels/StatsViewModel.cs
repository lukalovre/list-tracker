using System.Collections.Generic;
using Repositories;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;

namespace AvaloniaApplication1.ViewModels;

public partial class StatsViewModel(IDatasource datasource) : ViewModelBase
{
    public List<Axis> _1001XAxes { get; set; } = [];
    public List<ISeries> _1001 { get; } = [];
}
