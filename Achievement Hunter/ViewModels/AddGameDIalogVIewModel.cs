using Achievement_Hunter.ViewModels;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Achievement_Hunter.Classes;
using System.Threading.Tasks;
using System;
namespace Achievement_Hunter.ViewModels;

public partial class AddGameDialogViewModel : ViewModelBase
{
    private readonly Window _dialog;
    [ObservableProperty] private string _gameName;
    [ObservableProperty] private string _steamAppId;
    private static bool Adding = false;
    public AddGameDialogViewModel(Window dialog, string gameName)
    {
        _gameName = gameName;

        _dialog = dialog;
        _steamAppId = "";
    }

    [RelayCommand]
    public async Task Cancel()
    {

        _dialog.Close(new GameDialogResponse(false, null));

    }
    [RelayCommand]
    public async Task Add()
    {
        if (!Adding)
        {
            Adding = true;
            Game addedGame = new Game(GameName, SteamAppId);

            string errorMessage = await addedGame.InitializeAsync();

            if (errorMessage != "")
            {
                Adding = false;
                _dialog.Close(new GameDialogResponse(false, addedGame, errorMessage));

                return;
            }
            bool successAdding = await GameListManager.AddGameToList(addedGame);
            Adding = false;
            _dialog.Close(new GameDialogResponse(successAdding, addedGame, successAdding ? string.Empty : "Game is already in your list or you have a game with the same name"));
        }

    }
}