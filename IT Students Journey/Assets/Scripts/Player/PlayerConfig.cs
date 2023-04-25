using Newtonsoft.Json;
using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    public static PlayerConfig instance;

    public AchievementSO[] languageAchievementsSO;
    public AchievementSO completionistAchievementSO;

    [HideInInspector]
    public PlayerData playerData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
        DontDestroyOnLoad(this.gameObject);
        // PlayerPrefs.DeleteAll();
        LoadStats();
    }

    private void LoadStats()
    {
        if (PlayerPrefs.GetString("PlayerData") == string.Empty)
        {
            LoadDefaultData();
        }
        else
        {
            DeserializeData();
        }
    }

    private void LoadDefaultData()
    {
        playerData = new PlayerData();
        foreach (var ach in languageAchievementsSO)
        {
            playerData.progressDictionary.Add(ach.achievementName, 0);
            if (!playerData.levelScores.ContainsKey(ach.language) && ach.language != LanguageEnum.None)
            {
                playerData.levelScores.Add(ach.language, new LanguageData());
            }
        }
        SaveStats();
    }

    private void DeserializeData()
    {
        string json = PlayerPrefs.GetString("PlayerData");
        playerData = JsonConvert.DeserializeObject<PlayerData>(json);
    }

    private void SerializeData()
    {
        string json = JsonConvert.SerializeObject(playerData);
        PlayerPrefs.SetString("PlayerData", json);
    }

    public void SaveStats()
    {
        playerData.UpdateAchievementProgress();
        SerializeData();
    }
}
