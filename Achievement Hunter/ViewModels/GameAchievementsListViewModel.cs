using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Achievement_Hunter.Classes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Achievement_Hunter.ViewModels;

public partial class GameAchievementListViewModel : ViewModelBase
{
    private Game selectedGame;
    public List<Achievement> Achievements;
    public ObservableCollection<Achievement> FilteredAchievements { get; } = new ObservableCollection<Achievement>();
    [ObservableProperty] string _name;
    [ObservableProperty] string _searchText = "";
    private Action _navigateBack;
    public GameAchievementListViewModel(Game selectedGame, Action NavigateBack)
    {
        this.selectedGame = selectedGame;
        this.Name = selectedGame.name;
        this.Achievements = selectedGame.Achievements;
        this._navigateBack = NavigateBack;
        FilterList(SearchText);
    }

    partial void OnSearchTextChanged(string value)
    {
        FilterList(SearchText);
    }
    public void FilterList(string? query)
    {

        var filtered = Achievements.Where(g =>
            string.IsNullOrWhiteSpace(query) ||
            g.AchievementName.Contains(query, StringComparison.OrdinalIgnoreCase));

        FilteredAchievements.Clear();
        foreach (var achievement in filtered)
        {
            FilteredAchievements.Add(achievement);
        }
    }

    public void NavigateBack()
    {
        _navigateBack.Invoke();
    }

}