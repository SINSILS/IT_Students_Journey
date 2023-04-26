using System.Collections;
using TMPro;
using UnityEngine;

//Here achievements will be handled
public class AchievementPopUp : MonoBehaviour
{
    TMP_Text achievementLabel;
    int x = 0;
    private void Start()
    {
        achievementLabel = GameObject.FindWithTag("Achievement").GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        achievementLabel.text = "Achievement title " + x;
        x++;
    }

    private IEnumerator CheckAchievementProgress(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
        }
    }
}
