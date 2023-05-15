using ClearSky;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int sceneIndex;

    [SerializeField] private StudentController student;
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private UpgradeManager upgradeManager;
    [SerializeField] private ExamManager examManager;

    [SerializeField] private TMP_Text semester;
    [SerializeField] private TMP_Text score;
    int scoreValue = 0;
    int minLevel = 0;
    int maxLevel = 1;
    bool universityDone = false;
    bool examinating = false;
    bool mainBottomPlatformGone = false;
    bool _gameOver = false;

    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject question1Panel;
    [SerializeField] private GameObject question2Panel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject examPanel;


    // Start is called before the first frame update
    void Start()
    {
        setSceneIndex();
        InvokeRepeating("updateScoreAndLevel", 0.05f, 0.05f);
        showSemesterLabel("Semester " + maxLevel);
        student.setSceneIndex(sceneIndex);
        enemyManager.setScenIndex(sceneIndex);
        upgradeManager.setSceneIndex(sceneIndex);
        examManager.setSceneIndex(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        platformManager.spawnPlatform();
        enemyManager.spawnEnemy(platformManager.getPlatforms(), minLevel, maxLevel);
        handleUpgradePanel();
        handleExitPanel();
        if (student.getCurrentHP() <= 0 && !_gameOver)
        {
            gameOver();
        }
        if (sceneIndex == 3 && !mainBottomPlatformGone)
        {
            removeMainPlatform();
        }
        if (examManager.isExamDone() && examinating)
        {
            StartCoroutine(WaitBeforeResume());
            examinating = false;
        }
    }

    IEnumerator WaitBeforeResume()
    {
        yield return new WaitForSecondsRealtime(2f);
        resume(3);
    }

    void setSceneIndex()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void removeMainPlatform()
    {
        Platform mainBottomPlatform = GameObject.FindWithTag("MainBottomPlatform").GetComponent<Platform>();
        if (mainBottomPlatform.transform.position.x < -45f)
        {
            mainBottomPlatformGone = true;
            Destroy(GameObject.FindWithTag("MainBottomPlatform"));
        }
    }

    void updateScoreAndLevel()
    {
        scoreValue++;
        score.text = "Score : " + scoreValue;
        if (scoreValue % 1000 == 0 && maxLevel < 8)
        {
            examinating = true;
            examManager.generateQuestion(maxLevel);
            pause(3);
            maxLevel++;
            enemyManager.increaseEnemyCount();
            showSemesterLabel("Semester " + maxLevel);
            if (maxLevel == 4 && !student.gotHurt())
            {
                var language = (LanguageEnum)sceneIndex;
                PlayerConfig.instance.playerData.levelScores[language].noDamageReceived = 1;
            }
        }
        else if (scoreValue % 1000 == 0 && maxLevel == 8 && !universityDone)
        {
            examManager.generateQuestion(maxLevel);
            pause(3);
            showSemesterLabel("Real life problems!");
            universityDone = true;
            examinating = true;
        }
        else if (scoreValue % 1000 == 0 && minLevel < 4 && universityDone)
        {
            minLevel++;
        }
    }

    public void openQuestion1Panel()
    {
        exitPanel.SetActive(false);
        question1Panel.SetActive(true);
    }

    public void openQuestion2Panel()
    {
        exitPanel.SetActive(false);
        question2Panel.SetActive(true);
    }

    public void backToPreviousPanel()
    {
        exitPanel.SetActive(true);
        if (question1Panel.activeSelf)
        {
            question1Panel.SetActive(false);
        }
        else
        {
            question2Panel.SetActive(false);
        }
    }

    public void backToMainMenu()
    {
        resume(2);
        SceneManager.LoadScene(0);
    }

    public void restartGame()
    {
        resume(2);
        SceneManager.LoadScene(sceneIndex);
    }

    public void backToGame()
    {
        resume(1);
    }

    void handleExitPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!exitPanel.activeSelf && !upgradePanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf && !examPanel.activeSelf)
            {
                pause(1);
            }
            else if (exitPanel.activeSelf && !upgradePanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf && !examPanel.activeSelf)
            {
                resume(1);
            }
        }
    }

    void handleUpgradePanel()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!upgradePanel.activeSelf && !exitPanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf && !examPanel.activeSelf)
            {
                pause(0);
            }
            else if (upgradePanel.activeSelf && !exitPanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf && !examPanel.activeSelf)
            {
                resume(0);
            }
        }
    }

    //0 - upgrades panel, 1 - exit panel, 2 - others, 3 - exam panel
    void pause(int x)
    {
        Time.timeScale = 0f;
        if (x == 0)
        {
            upgradePanel.SetActive(true);
        }
        else if (x == 1)
        {
            exitPanel.SetActive(true);
        }
        else if (x == 3)
        {
            examPanel.SetActive(true);
        }
    }

    //0 - upgrades panel, 1 - exit panel, 2 - others, 3 - exam panel
    void resume(int x)
    {
        Time.timeScale = 1f;
        if (x == 0)
        {
            upgradePanel.SetActive(false);
        }
        else if (x == 1)
        {
            exitPanel.SetActive(false);
        }
        else if (x == 3)
        {
            examPanel.SetActive(false);
        }
    }

    void gameOver()
    {
        CancelInvoke("updateScoreAndLevel");
        _gameOver = true;
        updatePlayerConfig();
        Invoke("delayGameOver", 1f);
    }

    //1 - C#, 3 - Pyhton, 4 - JS

    private void updatePlayerConfig()
    {
        var language = (LanguageEnum)sceneIndex;
        var data = PlayerConfig.instance.playerData.levelScores[language];

        if (data.highScore < scoreValue)
        {
            data.highScore = scoreValue;
            PlayFabManager.instance.StartCloudUpdatePlayerStats();
        }
        if (data.semestersCompleted < maxLevel)
        {
            data.semestersCompleted = maxLevel;
        }
        PlayerConfig.instance.SaveStats();
    }

    private void OnApplicationQuit()
    {
        updatePlayerConfig();
    }

    void delayGameOver()
    {
        pause(2);
        gameOverPanel.SetActive(true);
    }

    IEnumerator fadeOutSemesterLabel()
    {
        float fadeDuration = 3f; // Duration of the fade effect in seconds
        float elapsedTime = 0f;
        Color originalColor = semester.color;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            semester.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        semester.enabled = false;
    }

    void showSemesterLabel(string text)
    {
        semester.text = text;
        semester.enabled = true;
        StartCoroutine(fadeOutSemesterLabel());
    }
}
