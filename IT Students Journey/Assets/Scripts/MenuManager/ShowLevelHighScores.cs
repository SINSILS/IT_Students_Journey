using TMPro;
using UnityEngine;

public class ShowLevelHighScores : MonoBehaviour
{
    public TMP_Text cSharpScore;
    public TMP_Text javaScriptScore;
    public TMP_Text pythonScore;

    private void Start()
    {
        cSharpScore.text = "Highest Score " + PlayerConfig.instance.playerData.levelScores[LanguageEnum.CSharp].highScore;
        javaScriptScore.text = "Highest Score " + PlayerConfig.instance.playerData.levelScores[LanguageEnum.JavaScript].highScore;
        pythonScore.text = "Highest Score " + PlayerConfig.instance.playerData.levelScores[LanguageEnum.Python].highScore;
    }
}
