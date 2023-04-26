using System.Collections.Generic;
using UnityEngine;

public class AchievementDisplayer : MonoBehaviour
{
    public AchievementUI achievementUIPrefab;

    private Color32 unlockedImageColor = new Color32(79, 180, 0, 255);
    private List<AchievementUI> achievementsUIList = new List<AchievementUI>();

    private void Start()
    {
        ShowAchievements();
    }

    public void ShowAchievements()
    {
        int completed = 0;
        AchievementUI completionistUI = default;
        if (achievementsUIList.Count == 0)
        {
            foreach (var item in PlayerConfig.instance.languageAchievementsSO)
            {
                var score = PlayerConfig.instance.playerData.progressDictionary[item.achievementName].progressValue;
                var tempUI = Instantiate(achievementUIPrefab, transform);
                achievementsUIList.Add(tempUI);
                tempUI.logo.sprite = item.achievementSprite;
                tempUI.logo.rectTransform.sizeDelta = item.imageRect;
                tempUI.title.text = item.achievementName;
                tempUI.description.text = item.description;

                if (score >= item.goal)
                {
                    tempUI.completeText.text = $"Completed: {item.goal}/{item.goal}";
                    completed++;
                    UnlockAchievement(tempUI);
                }
                else
                {
                    tempUI.completeText.text = $"Completed: {score}/{item.goal}";
                }

                if (item.achievementName == "Completionist")
                {
                    completionistUI = tempUI;
                }
            }
            completionistUI.completeText.text = $"Completed: {completed}/{PlayerConfig.instance.languageAchievementsSO.Length - 1}";
        }
        if (completed == PlayerConfig.instance.completionistAchievementSO.goal)
        {
            UnlockAchievement(completionistUI);
        }
    }

    private void UnlockAchievement(AchievementUI ach)
    {
        ach.panel.color = unlockedImageColor;
        ach.title.color = Color.white;
        ach.description.color = Color.white;
        ach.logo.color = Color.white;
        ach.completeText.color = Color.white;
    }
}
