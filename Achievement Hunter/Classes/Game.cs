using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using Microsoft.VisualBasic;
using System.Net.Http;
using System.Text.Json;


namespace Achievement_Hunter.Classes;

public class Game : BaseObject
{

    public string name { get; set; }

    public string steamAppId { get; set; }

    private List<Achievement> achievements = new List<Achievement>();
    public List<Achievement> Achievements
    {
        get { return achievements; }
    }



    public Game(string name, string steamAppId)
    {
        this.name = name;
        this.steamAppId = steamAppId;
    }



    public async Task InitializeAsync()
    {

        string proxyUrl = $"https://steam-api-xt6g.onrender.com/achievements/{steamAppId}";

        using HttpClient client = new HttpClient();
        var response = await client.GetStringAsync(proxyUrl);


        var achievementsJson = JsonSerializer.Deserialize<List<Achievement>>(response, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        achievements.Clear();
        achievements.AddRange(achievementsJson);
    }




}