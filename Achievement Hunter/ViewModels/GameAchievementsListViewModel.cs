using System.Collections.ObjectModel;
using Achievement_Hunter.Classes;
using CommunityToolkit.Mvvm.ComponentModel;
namespace Achievement_Hunter.ViewModels;

public partial class GameAchievementListViewModel : ViewModelBase
{
    private Game selectedGame;
    public ObservableCollection<Achievement> Achievements { get; }
    [ObservableProperty] string _name;
    public GameAchievementListViewModel(Game selectedGame)
    {
        this.selectedGame = selectedGame;
        this.Name = selectedGame.name;
        this.Achievements = new ObservableCollection<Achievement>(selectedGame.Achievements);
    }

}