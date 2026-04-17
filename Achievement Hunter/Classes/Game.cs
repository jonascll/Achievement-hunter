using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using Microsoft.VisualBasic;

namespace Achievement_Hunter.Classes;

public class Game : BaseObject
{
    private IConfiguration config;
    private IBrowsingContext context;
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string achievementsUrl;

    public string AchievementsUrl
    {
        get { return achievementsUrl; }
        set { achievementsUrl = value; }
    }
    private List<Achievement> _achievements;
    public List<Achievement> Achievements
    {
        get { return _achievements; }
    }



    public Game(string name, string achievementsUrl)
    {
        this.name = name;
        this.achievementsUrl = achievementsUrl;
        config = Configuration.Default.WithDefaultLoader();
        context = BrowsingContext.New(config);

    }

    public async Task InitializeAsync()
    {
        this._achievements = await LoadAchievements();
    }
    private async Task<List<Achievement>> LoadAchievements()
    {


        var document = await context.OpenAsync(achievementsUrl);
        var achievementTables = document.QuerySelectorAll("table.wikitable");
        List<Achievement> achievements = new();

        foreach (var achievementTable in achievementTables)
        {

            if (achievementTable.Id == "tpt-5") continue;
            var rows = achievementTable.QuerySelectorAll("tbody tr");

            foreach (var row in rows)
            {
                var headers = row.Closest("table")?.QuerySelectorAll("th");
                var cells = row.QuerySelectorAll("td");
                if (cells.Length == 0 || headers == null) continue;
                string achievementName = "";
                string achievementDescription = "";
                string achievementUnlockText = "";
                var achievementsData = row.QuerySelectorAll("td");
                for (int i = 0; i < cells.Length; i++)
                {
                    var headerText = headers[i].TextContent.Trim().ToLower();
                    var cellValue = cells[i].TextContent.Trim();
                    var data = achievementsData[i].Children;
                    if (headerText.Contains("name"))
                    {
                        achievementName = cellValue;
                    }
                    if (headerText.Contains("description"))
                    {
                        achievementDescription = cellValue;

                    }
                    if (headerText.Contains("unlock"))
                    {


                        achievementUnlockText = cellValue;
                    }
                }
                Achievement achievement = new Achievement(achievementName, achievementDescription, achievementUnlockText);
                achievements.Add(achievement);
            }


        }





        return achievements;
    }

}