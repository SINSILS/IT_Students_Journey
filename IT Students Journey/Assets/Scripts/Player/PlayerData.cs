using System.Collections.Generic;

public class LanguageData
{
    public int highScore;
    public int semestersCompleted;
    public int mobsKilled;
    public int noDamageReceived;
}

[System.Serializable]
public class PlayerData
{
    public Dictionary<LanguageEnum, LanguageData> levelScores = new Dictionary<LanguageEnum, LanguageData>();
    public Dictionary<string, int> progressDictionary = new Dictionary<string, int>();

    public void UpdateAchievementProgress()
    {
        progressDictionary["C# Graduate"] = levelScores[LanguageEnum.CSharp].semestersCompleted;
        progressDictionary["C# Master"] = levelScores[LanguageEnum.CSharp].mobsKilled;
        progressDictionary["C# Untouchable"] = levelScores[LanguageEnum.CSharp].noDamageReceived;

        progressDictionary["JavaScript Graduate"] = levelScores[LanguageEnum.JavaScript].semestersCompleted;
        progressDictionary["JavaScript Master"] = levelScores[LanguageEnum.JavaScript].mobsKilled;
        progressDictionary["JavaScript Untouchable"] = levelScores[LanguageEnum.JavaScript].noDamageReceived;

        progressDictionary["Python Graduate"] = levelScores[LanguageEnum.Python].semestersCompleted;
        progressDictionary["Python Master"] = levelScores[LanguageEnum.Python].mobsKilled;
        progressDictionary["Python Untouchable"] = levelScores[LanguageEnum.Python].noDamageReceived;
    }
}