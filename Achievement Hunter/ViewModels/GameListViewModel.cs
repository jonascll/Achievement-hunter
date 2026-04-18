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

    public ObservableCollection<Game> FilteredGames { get; } = new ObservableCollection<Game>();
    public List<Game> Games;
    public GameListViewModel(List<Game> games)
    {

        this.Games = games;
        FilterList(GameName);
    }

    partial void OnGameNameChanged(string? value)
    {
        FilterList(value);
    }
    private void FilterList(string? query)
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


}