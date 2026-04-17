using Achievement_Hunter.Classes;
using Achievement_Hunter.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Text.Json;

namespace Achievement_Hunter.ViewModels;

public partial class GameListViewModel : ViewModelBase
{
    [ObservableProperty] private string _gameName = "";


    public void WriteGameDataToJson(Game game)
    {
        string jsonString = JsonSerializer.Serialize(game);
        Console.WriteLine(jsonString);
    }
}