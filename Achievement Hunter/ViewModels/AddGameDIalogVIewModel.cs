using Achievement_Hunter.ViewModels;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Achievement_Hunter.Classes;
using System.Threading.Tasks;
namespace Achievement_Hunter.ViewModels;

public partial class AddGameDialogViewModel : ViewModelBase
{
    private readonly Window _dialog;
    [ObservableProperty] private string _gameName;
    [ObservableProperty] private string _achievementsUrl;
    public AddGameDialogViewModel(Window dialog, string gameName)
    {
        _gameName = gameName;

        _dialog = dialog;
        _achievementsUrl = "";
    }

    [RelayCommand]
    public async Task Cancel()
    {

        _dialog.Close(new GameDialogResponse(false, null));

    }
    [RelayCommand]
    public async Task Add()
    {
        Game addedGame = new Game(GameName, AchievementsUrl);
        await addedGame.InitializeAsync();
        _dialog.Close(new GameDialogResponse(true, addedGame));
    }
}