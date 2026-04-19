using Achievement_Hunter.Classes;
using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Achievement_Hunter.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase _currentPage;
    [ObservableProperty] private int _windowWidth;
    [ObservableProperty] private int _windowHeight;
    [ObservableProperty] private bool _canResize = true;
    public MainWindowViewModel(int windowWidth, int windowHeight)
    {
        GameListManager.LoadJson();
        _currentPage = new GameListViewModel(GameListManager.listOfGames, NavigateToGameAchievements);
        this.WindowHeight = windowHeight;
        this.WindowWidth = windowWidth;
    }



    public void NavigateToGameAchievements(Game selectedGame)
    {
        CurrentPage = new GameAchievementListViewModel(selectedGame, NavigateToGameList);
        WindowWidth = 700;
        WindowHeight = 600;
        CanResize = false;
    }
    public void NavigateToGameList()
    {
        CurrentPage = new GameListViewModel(GameListManager.listOfGames, NavigateToGameAchievements);
        WindowWidth = 800;
        WindowHeight = 450;
        CanResize = true;
    }
}
