using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using AvaloniaApplication1.Models;
using DynamicData;
using ReactiveUI;
using Repositories;

namespace AvaloniaApplication1.ViewModels;

public class ItemViewModel<TItem, TGridItem, TEventItem> : ViewModelBase
where TItem : IItem
where TGridItem : IGridItem
where TEventItem : IExternalItem
{
    public virtual float AmountToMinutesModifier => 1f;
    private readonly IDatasource _datasource;
    private TGridItem _selectedGridItem;
    private List<TItem> _itemList;
    private TItem _selectedItem;
    private int _gridCountItems;

    private int _gridCountItemsBookmarked;

    public ObservableCollection<TGridItem> GridItems { get; set; }
    public ObservableCollection<TGridItem> GridItemsBookmarked { get; set; }

    public TItem SelectedItem
    {
        get => _selectedItem;
        set => this.RaiseAndSetIfChanged(ref _selectedItem, value);
    }

    public ReactiveCommand<Unit, Unit> Search { get; }
    public ReactiveCommand<Unit, Unit> OpenLink { get; }

    public int GridCountItems
    {
        get => _gridCountItems;
        private set => this.RaiseAndSetIfChanged(ref _gridCountItems, value);
    }

    public int GridCountItemsBookmarked
    {
        get => _gridCountItemsBookmarked;
        private set => this.RaiseAndSetIfChanged(ref _gridCountItemsBookmarked, value);
    }
    public TGridItem SelectedGridItem
    {
        get => _selectedGridItem;
        set
        {
            _selectedGridItem = value;
            SelectedItemChanged();
        }
    }

    public string SearchText { get; set; }

    public ItemViewModel(IDatasource datasource)
    {
        _datasource = datasource;

        GridItems = [];
        GridItemsBookmarked = [];
        ReloadData();

        Search = ReactiveCommand.Create(SearchAction);
        OpenLink = ReactiveCommand.Create(OpenLinkAction);

        SelectedGridItem = GridItems.LastOrDefault();
    }

    public virtual List<string> OpenLinkAlternativeParameters()
    {
        return [];
    }

    private void OpenLinkAction()
    {
        HtmlHelper.OpenLink(SelectedItem.ExternalID, OpenLinkAlternativeParameters());
    }

    private void SearchAction()
    {
        SearchText = SearchText.Trim();

        if (string.IsNullOrWhiteSpace(SearchText))
        {
            GridItemsBookmarked.Clear();
            GridItemsBookmarked.AddRange(LoadData());
            return;
        }

        // var searchMovie = new Movie { Director = SearchText, Title = SearchText };

        GridItemsBookmarked.Clear();
        GridItemsBookmarked.AddRange(LoadDataBookmarked());
    }

    private void ReloadData()
    {
        GridItems.Clear();
        GridItems.AddRange(LoadData());
        GridCountItems = GridItems.Count;

        GridItemsBookmarked.Clear();
        GridItemsBookmarked.AddRange(LoadDataBookmarked());
        GridCountItemsBookmarked = GridItemsBookmarked.Count;
    }

    private List<TGridItem> LoadData()
    {
        _itemList = _datasource.GetList<TItem>();

        return _itemList
            .OrderBy(o => o.Date)
            .Select((o, i) => Convert(i, o))
            .ToList();
    }

    private List<TGridItem> LoadDataBookmarked(int? yearsAgo = null)
    {
        _itemList = _datasource.GetList<TItem>();
        var doneList = _datasource.GetDoneList<TEventItem>().Select(o => o.ExternalID);

        return _itemList
        .Where(o => !doneList.Contains(o.ExternalID))
            .OrderBy(o => o.Date)
            .Select((o, i) => Convert(i, o))
            .ToList();
    }

    public virtual TGridItem Convert(int index, TItem i)
    {
        return default;
    }

    public void SelectedItemChanged()
    {
        if (SelectedGridItem == null)
        {
            return;
        }

        SelectedItem = _itemList.First(o => o.ID == SelectedGridItem.ID);
    }
}
