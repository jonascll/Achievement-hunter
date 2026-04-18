using System.Text.Json.Serialization;

public class Achievement
{
    [JsonPropertyName("displayName")]
    public string AchievementName { get; set; }

    [JsonPropertyName("description")]
    public string AchievementDescription { get; set; }

    [JsonPropertyName("icon")]
    public string IconUrl { get; set; }
    public Achievement(string achievementName, string achievementDescription, string iconUrl)
    {
        this.AchievementName = achievementName;
        this.AchievementDescription = achievementDescription;
        this.IconUrl = iconUrl;
    }
}