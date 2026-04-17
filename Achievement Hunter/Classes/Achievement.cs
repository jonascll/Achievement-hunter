using System.Text.Json.Serialization;

public class Achievement
{
    [JsonPropertyName("displayName")]
    public string AchievementName { get; set; }

    [JsonPropertyName("description")]
    public string AchievementDescription { get; set; }


    public Achievement(string achievementName, string achievementDescription)
    {
        this.AchievementName = achievementName;
        this.AchievementDescription = achievementDescription;
    }
}