public class Achievement
{
    private string _achievementName;
    public string AchievementName
    {
        get { return _achievementName; }
    }
    private string _achievementDescription;
    public string AchievementDescription
    {
        get { return _achievementDescription; }
    }
    private string _achievementUnlockText;
    public string AchievementUnlockText
    {
        get { return _achievementUnlockText; }
    }

    public Achievement(string achievementName, string achievementDescription, string achievementUnlockText = "")
    {
        this._achievementName = achievementName;
        this._achievementDescription = achievementDescription;
        this._achievementUnlockText = achievementUnlockText;
    }
}