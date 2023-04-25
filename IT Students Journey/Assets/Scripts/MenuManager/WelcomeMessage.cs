using TMPro;
using UnityEngine;

public class WelcomeMessage : MonoBehaviour
{
    public TMP_Text welcomeText;

    public void SayHelloToPlayer(string playerName, bool hasAccount = false)
    {
        if (PlayerPrefs.GetInt("FirstLogin") > 0 || hasAccount)
        {
            welcomeText.text = $"Welcome back student {playerName}";
        }
        else
        {
            welcomeText.text = $"Hello new student {playerName}";
        }
    }
}
