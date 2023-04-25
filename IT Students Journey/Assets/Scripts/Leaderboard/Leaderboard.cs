using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerRatingStruct
{
    public int rank;
    public string displayName;
    public int score;
}

public class Leaderboard : MonoBehaviour
{
    public LeaderboardUI ratingPrefab;
    private List<LeaderboardUI> uiList = new List<LeaderboardUI>();

    public void GetLeaderboard(string highScoreType)
    {
        if (uiList.Count > 0)
        {
            for (int i = 0; i < uiList.Count; i++)
            {
                Destroy(uiList[i].gameObject);
            }
            uiList.Clear();
        }

        var requestLeaderboard = new GetLeaderboardRequest { StartPosition = 0, StatisticName = highScoreType, MaxResultsCount = 10 };
        PlayFabClientAPI.GetLeaderboard(requestLeaderboard, OnGetLeaderboard, OnErrorLeaderboard);
    }

    private void OnGetLeaderboard(GetLeaderboardResult result)
    {
        foreach (PlayerLeaderboardEntry player in result.Leaderboard)
        {
            var tempUI = Instantiate(ratingPrefab, transform);
            tempUI.displayNameText.text = player.DisplayName;
            tempUI.rankText.text = "#" + (player.Position + 1);
            tempUI.scoreText.text = player.StatValue.ToString();
            uiList.Add(tempUI);
        }
    }

    private void OnErrorLeaderboard(PlayFabError error)
    {
        Debug.LogError("FAILED TO GET LEADERBOARD");
    }
}
