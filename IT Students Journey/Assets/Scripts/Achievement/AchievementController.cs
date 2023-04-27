using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementController : MonoBehaviour
{
    public RectTransform canvasRectTransform;
    public Image achievementLogo;
    public TMP_Text achievementText;
    public float flyInDuration = 3f;
    public float flyOutDuration = 3f;
    public float waitDuration = 3f;

    private Vector2 startPosition = new Vector2(900f, 220f);
    private Vector2 endPosition = new Vector2(440f, 220f);

    private void Start()
    {
        StartCoroutine(CheckAchievementProgress(1f));
    }

    public void ShowAchievement()
    {
        LeanTween.move(gameObject, canvasRectTransform.TransformPoint(endPosition), flyInDuration)
            .setOnComplete(() =>
            {
                // Wait for specified duration
                LeanTween.delayedCall(gameObject, waitDuration, () =>
                {
                    // Start flying out
                    LeanTween.move(gameObject, canvasRectTransform.TransformPoint(startPosition), flyOutDuration);
                });
            });
    }

    private IEnumerator CheckAchievementProgress(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            PlayerConfig.instance.playerData.UpdateAchievementProgress();
            foreach (var item in PlayerConfig.instance.languageAchievementsSO)
            {
                var progressStruct = PlayerConfig.instance.playerData.progressDictionary[item.achievementName];

                if (progressStruct.progressValue >= item.goal && progressStruct.achievementShown == false)
                {
                    achievementText.text = item.achievementName;
                    achievementLogo.sprite = item.achievementSprite;
                    ShowAchievement();
                    PlayerConfig.instance.playerData.progressDictionary[item.achievementName].achievementShown = true;
                }
            }
        }
    }
}