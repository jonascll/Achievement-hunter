using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
namespace Achievement_Hunter.Classes;

static class GameListManager
{
    public static List<Game> listOfGames = new List<Game>();
    private static string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
    private static string appFolder = Path.Combine(folder, "Achievement_Hunter");
    private static string GamesJsonPath = Path.Combine(appFolder, "games.json");



    public static async Task AddGameToList(Game game)
    {
        if (!listOfGames.Any(listGame => listGame.name == game.name || listGame.steamAppId == game.steamAppId))
        {
            listOfGames.Add(game);
            await UpdateJson();
        }
    }

    async private static Task UpdateJson()
    {
        Directory.CreateDirectory(appFolder);


        string jsonString = JsonSerializer.Serialize(listOfGames);
        File.WriteAllText(GamesJsonPath, jsonString);
    }

}