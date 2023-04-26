using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using UnityEngine;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager instance;

    public GameObject noInternetGO;
    public Button[] buttons;
    private WelcomeMessage welcomeMessage;

    private void Awake()
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

        welcomeMessage = FindObjectOfType<WelcomeMessage>();
        InitializePlayFab();
    }

    private void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            noInternetGO.SetActive(true);
        }
        else
        {
            if (noInternetGO.activeInHierarchy)
            {
                noInternetGO.SetActive(false);
            }
        }
    }

    private void InitializePlayFab()
    {
        Login();
    }

    #region Login

    private void Login()
    {
        var id = SystemInfo.deviceUniqueIdentifier;
        var request = new LoginWithCustomIDRequest { CustomId = id, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("LOGGED IN");
        GetPlayerProfile();
        foreach(var btn in buttons) {
            btn.interactable = true;
        }
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Login();
        Debug.LogError("FAILED TO LOGIN");
    }

    #endregion

    #region Get Player Profile (if Player data exists)

    private void GetPlayerProfile()
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest { ProfileConstraints = new PlayerProfileViewConstraints { ShowDisplayName = true } },
        result =>
        {
            if (string.IsNullOrEmpty(result.PlayerProfile.DisplayName))
            {
                SetRandomName();
            }
            else
            {
                GetPlayerProfile(result.PlayerProfile.PlayerId);
            }
        },
        error => { Debug.LogError(error.GenerateErrorReport()); });
    }

    private void GetPlayerProfile(string playFabId)
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {
            PlayFabId = playFabId,
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowDisplayName = true
            }

        }, OnGetPlayerProfileSuccess, OnGetPlayerProfileFailure);
    }

    private void OnGetPlayerProfileFailure(PlayFabError obj)
    {
        Debug.LogError("FAILED TO GET PLAYER PROFILE");
    }

    private void OnGetPlayerProfileSuccess(GetPlayerProfileResult obj)
    {
        welcomeMessage.SayHelloToPlayer(obj.PlayerProfile.DisplayName, true);
        GetPlayerStatistics();
    }

    #endregion

    #region Get Player Statistics (if Player data exists)

    public void GetPlayerStatistics()
    {
        PlayFabClientAPI.GetPlayerStatistics(
            new GetPlayerStatisticsRequest(),
            OnGetStats,
            error => Debug.LogError(error.GenerateErrorReport())
            );
    }

    void OnGetStats(GetPlayerStatisticsResult result)
    {
        foreach (var eachStat in result.Statistics)
        {
            switch (eachStat.StatisticName)
            {
                case "CSharpHighScore":
                    if (eachStat.Value > PlayerConfig.instance.playerData.levelScores[LanguageEnum.CSharp].highScore)
                    {
                        PlayerConfig.instance.playerData.levelScores[LanguageEnum.CSharp].highScore = eachStat.Value;
                    }
                    break;
                case "JavaScriptHighScore":
                    if (eachStat.Value > PlayerConfig.instance.playerData.levelScores[LanguageEnum.JavaScript].highScore)
                    {
                        PlayerConfig.instance.playerData.levelScores[LanguageEnum.JavaScript].highScore = eachStat.Value;
                    }
                    break;
                case "PythonHighScore":
                    if (eachStat.Value > PlayerConfig.instance.playerData.levelScores[LanguageEnum.Python].highScore)
                    {
                        PlayerConfig.instance.playerData.levelScores[LanguageEnum.Python].highScore = eachStat.Value;
                    }
                    break;
            }
        }
    }
    #endregion

    #region Set Random Name (if Player doesn't exist)

    private void SetRandomName()
    {
        var nameGenerator = new RandomNameGenerator();
        string name = nameGenerator.GetRandomName();

        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest { DisplayName = name }, OnGiveSucess, OnGiveFailure);
    }

    private void OnGiveSucess(UpdateUserTitleDisplayNameResult obj)
    {
        welcomeMessage.SayHelloToPlayer(obj.DisplayName);
        PlayerPrefs.SetInt("FirstLogin", 1);
    }

    private void OnGiveFailure(PlayFabError obj)
    {
        Debug.LogError("FAILED TO UPDATE USER NAME");
    }
    #endregion

    #region Call Cloud Script to Update Statistics

    public void StartCloudUpdatePlayerStats()
    {
        PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
        {
            FunctionName = "UpdatePlayerStats",
            FunctionParameter = new
            {
                csharpHigh = PlayerConfig.instance.playerData.levelScores[LanguageEnum.CSharp].highScore,
                jsHigh = PlayerConfig.instance.playerData.levelScores[LanguageEnum.JavaScript].highScore,
                pythonHigh = PlayerConfig.instance.playerData.levelScores[LanguageEnum.Python].highScore
            },
            GeneratePlayStreamEvent = true,
        }, OnCloudUpdateStats, OnErrorShared);
    }

    private void OnCloudUpdateStats(ExecuteCloudScriptResult result)
    {
        JsonObject jsonResult = (JsonObject)result.FunctionResult;
        object messageValue;
        jsonResult.TryGetValue("messageValue", out messageValue);
        Debug.Log(messageValue);
    }

    private void OnErrorShared(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
        Debug.Log("COULDNT UPDATE CLOUD");
    }

    #endregion
}
