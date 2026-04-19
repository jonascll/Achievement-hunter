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
        if (!CheckIfGameAlreadyInList(game))
        {

            listOfGames.Add(game);
            await UpdateJson();
            return true;
        }
        return false;

    }

    public static async Task<bool> NotifyGameChanged()
    {
        try
        {
            await UpdateJson();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }

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

    public static bool CheckIfGameAlreadyInList(Game game)
    {
        return listOfGames.Any(listGame => listGame.name == game.name);
    }

    public static Game CheckForCopyableAchievementData(Game game)
    {
        Game? copyGame = null;
        if (listOfGames.Any(listGame => listGame.steamAppId == game.steamAppId))
        {
            copyGame = listOfGames.Find(g => g.steamAppId == game.steamAppId);
            if (copyGame != null)
            {
                foreach (Achievement achievement in copyGame.Achievements)
                {
                    game.Achievements.Add(new Achievement(achievement.AchievementName, achievement.AchievementDescription, achievement.IconUrl));
                }
            }

        }
        return copyGame;
    }
}

