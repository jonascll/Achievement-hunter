using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Achievement_Hunter.Classes;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class Achievement : ObservableObject
{
    [JsonPropertyName("displayName")]
    public string AchievementName { get; set; }

    [JsonPropertyName("description")]
    public string AchievementDescription { get; set; }

    [JsonPropertyName("icon")]
    public string IconUrl { get; set; }
    [ObservableProperty, NotifyPropertyChangedFor(nameof(CheckboxText))] private bool _completed;

    public string CheckboxText => Completed ? "Completed" : "Not Completed";


    public Achievement(string achievementName, string achievementDescription, string iconUrl)
    {
        this.AchievementName = achievementName;
        this.AchievementDescription = achievementDescription;
        this.IconUrl = iconUrl;
        this.Completed = false;
    }

    [RelayCommand]
    public async Task NotifyGameChanged()
    {
        await GameListManager.NotifyGameChanged();
    }
}