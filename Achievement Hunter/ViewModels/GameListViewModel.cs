using Achievement_Hunter.Classes;
using Achievement_Hunter.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Achievement_Hunter.ViewModels;

public partial class GameListViewModel : ViewModelBase
{
    [ObservableProperty] private string _gameName = "";
    [ObservableProperty] private Game? _selectedGame;

    private readonly Action<Game> _onGameSelected;
    public ObservableCollection<Game> FilteredGames { get; } = new ObservableCollection<Game>();
    public List<Game> Games;
    public GameListViewModel(List<Game> games, Action<Game> onGameSelected)
    {

        this.Games = games;
        this._onGameSelected = onGameSelected;
        FilterList(GameName);
    }

    partial void OnGameNameChanged(string value)
    {
        FilterList(value);
    }
    public void FilterList(string? query)
    {
        var filtered = Games.Where(g =>
            string.IsNullOrWhiteSpace(query) ||
            g.name.Contains(query, StringComparison.OrdinalIgnoreCase));

        FilteredGames.Clear();
        foreach (var game in filtered)
        {
            FilteredGames.Add(game);
        }
    }
    public void RequestNavigation()
    {
        if (SelectedGame != null)
        {
            _onGameSelected?.Invoke(SelectedGame);

        }
    }

}