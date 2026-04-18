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



    public static async Task<bool> AddGameToList(Game game)
    {
        if (!listOfGames.Any(listGame => listGame.name == game.name || listGame.steamAppId == game.steamAppId))
        {

            listOfGames.Add(game);
            await UpdateJson();
            return true;
        }
        return false;

    }

    async private static Task UpdateJson()
    {
        Directory.CreateDirectory(appFolder);


        string jsonString = JsonSerializer.Serialize(listOfGames);
        File.WriteAllText(GamesJsonPath, jsonString);
    }

    public static void LoadJson()
    {
        if (!File.Exists(GamesJsonPath))
        {
            listOfGames = new List<Game>();
            return;
        }

        try
        {
            string jsonString = File.ReadAllText(GamesJsonPath);

            listOfGames = JsonSerializer.Deserialize<List<Game>>(jsonString) ?? new List<Game>();
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Failed to load games: {ex.Message}");
            listOfGames = new List<Game>();
        }
    }
}

