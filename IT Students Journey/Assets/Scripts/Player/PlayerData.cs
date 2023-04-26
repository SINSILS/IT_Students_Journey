using System.Collections.Generic;

public class LanguageData
{
    public int highScore;
    public int semestersCompleted;
    public int mobsKilled;
    public int noDamageReceived;
}

public class ProgressData
{
    public int progressValue;
    public bool achievementShown;
}

[System.Serializable]
public class PlayerData
{
    public Dictionary<LanguageEnum, LanguageData> levelScores = new Dictionary<LanguageEnum, LanguageData>();
    public Dictionary<string, ProgressData> progressDictionary = new Dictionary<string, ProgressData>();

    public void UpdateAchievementProgress()
    {
        progressDictionary["C# Graduate"].progressValue = levelScores[LanguageEnum.CSharp].semestersCompleted;
        progressDictionary["C# Master"].progressValue = levelScores[LanguageEnum.CSharp].mobsKilled;
        progressDictionary["C# Untouchable"].progressValue = levelScores[LanguageEnum.CSharp].noDamageReceived;

        progressDictionary["JavaScript Graduate"].progressValue = levelScores[LanguageEnum.JavaScript].semestersCompleted;
        progressDictionary["JavaScript Master"].progressValue = levelScores[LanguageEnum.JavaScript].mobsKilled;
        progressDictionary["JavaScript Untouchable"].progressValue = levelScores[LanguageEnum.JavaScript].noDamageReceived;

        progressDictionary["Python Graduate"].progressValue = levelScores[LanguageEnum.Python].semestersCompleted;
        progressDictionary["Python Master"].progressValue = levelScores[LanguageEnum.Python].mobsKilled;
        progressDictionary["Python Untouchable"].progressValue = levelScores[LanguageEnum.Python].noDamageReceived;
    }
}