using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum LanguageEnum
{
    None = 0,
    CSharp = 1,
    Python = 3,
    JavaScript = 4
}

[CreateAssetMenu(fileName = "New Achievement", menuName = "SO/Achievement")]
[System.Serializable]
public class AchievementSO : ScriptableObject
{
    public LanguageEnum language;
    public Sprite achievementSprite;
    public Vector2 imageRect = new Vector2(100, 100);
    public string achievementName;
    public string description;
    public int goal;
}
