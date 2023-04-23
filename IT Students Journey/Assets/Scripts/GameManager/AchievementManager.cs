using TMPro;
using UnityEngine;

//Here achievements will be handled
public class AchievementManager : MonoBehaviour
{
    TMP_Text achievementLabel;
    int x = 0;
    private void Start()
    {
        achievementLabel = GameObject.FindWithTag("Achievement").GetComponentInChildren<TMP_Text>(); //GetComponent<TMP_Text>();
    }

    private void Update()
    {
        achievementLabel.text = "Achievement title " + x;
        x++;
    }
}
