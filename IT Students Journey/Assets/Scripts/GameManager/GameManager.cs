using ClearSky;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int sceneIndex;
    bool gameOver = false;

    public StudentController student;
    public PlatformManager platformManager;
    public EnemyManager enemyManager;
    public UpgradeManager upgradeManager;
    public ExamManager examManager;

    public TMP_Text semester;
    public TMP_Text score;
    int scoreValue = 0;
    int minLevel = 0;
    int maxLevel = 1;
    bool universityDone = false;
    bool examinating = false;
    bool mainBottomPlatformGone = false;

    GameObject upgradePanel;
    GameObject exitPanel;
    GameObject question1Panel;
    GameObject question2Panel;
    GameObject gameOverPanel;
    GameObject examPanel;


    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Resume(2);
        InvokeRepeating("updateScoreAndLevel", 0.05f, 0.05f);
        //InvokeRepeating("updateScoreAndLevel", 0.005f, 0.005f);
        Invoke("setupPanels", 0.0001f); // Wait for 0.0001 seconds before calling setupPanels()
        ShowSemesterLabel("Semester " + maxLevel);
        student.setSceneIndex(sceneIndex);
        enemyManager.setScenIndex(sceneIndex);
        upgradeManager.setSceneIndex(sceneIndex);
        examManager.setSceneIndex(sceneIndex);
    }

    // Update is called once per frame
    void Update()
    {
        enemyManager.spawnEnemy(platformManager.getPlatforms(), minLevel, maxLevel);
        handleUpgradePanel();
        handleExitPanel();
        if (student.getCurrentHP() <= 0 && !gameOver)
        {
            GameOver();
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
        Resume(3);
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
            Pause(3);
            maxLevel++;
            enemyManager.increaseEnemyCount();
            ShowSemesterLabel("Semester " + maxLevel);
            if (maxLevel == 3 && !student.GotHurt())
            {
                var language = (LanguageEnum)sceneIndex;
                PlayerConfig.instance.playerData.levelScores[language].noDamageReceived = 1;
            }
        }
        else if (scoreValue % 1000 == 0 && maxLevel == 8 && !universityDone)
        {
            examManager.generateQuestion(maxLevel);
            Pause(3);
            ShowSemesterLabel("Real life problems!");
            universityDone = true;
        }
        else if (scoreValue % 1000 == 0 && minLevel < 4 && universityDone)
        {
            minLevel++;
        }
    }

    void setupPanels()
    {
        upgradePanel = GameObject.FindWithTag("UpgradePanel");
        upgradePanel.SetActive(false);

        exitPanel = GameObject.FindWithTag("Exit");
        exitPanel.SetActive(false);

        question1Panel = GameObject.FindWithTag("QuestionPanel1");
        question1Panel.SetActive(false);

        question2Panel = GameObject.FindWithTag("QuestionPanel2");
        question2Panel.SetActive(false);

        gameOverPanel = GameObject.FindWithTag("GameOver");
        gameOverPanel.SetActive(false);

        examPanel = GameObject.FindWithTag("Exam");
        examPanel.SetActive(false);
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
        SceneManager.LoadScene(0);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void backToGame()
    {
        Resume(1);
    }

    void handleExitPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!exitPanel.activeSelf && !upgradePanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf && !examPanel.activeSelf)
            {
                Pause(1);
            }
            else if (exitPanel.activeSelf && !upgradePanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf && !examPanel.activeSelf)
            {
                Resume(1);
            }
        }
    }

    void handleUpgradePanel()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!upgradePanel.activeSelf && !exitPanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf && !examPanel.activeSelf)
            {
                Pause(0);
            }
            else if (upgradePanel.activeSelf && !exitPanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf && !examPanel.activeSelf)
            {
                Resume(0);
            }
        }
    }

    //0 - upgrades panel, 1 - exit panel, 2 - others, 3 - exam panel
    void Pause(int x)
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
    void Resume(int x)
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

    void GameOver()
    {
        CancelInvoke("updateScoreAndLevel");
        gameOver = true;
        UpdatePlayerConfig();
        Invoke("DelayGameOver", 1f);
    }

    //1 - C#, 3 - Pyhton, 4 - JS

    private void UpdatePlayerConfig()
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
        UpdatePlayerConfig();
    }

    void DelayGameOver()
    {
        Pause(2);
        gameOverPanel.SetActive(true);
    }

    IEnumerator FadeOutSemesterLabel()
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

    void ShowSemesterLabel(string text)
    {
        semester.text = text;
        semester.enabled = true;
        StartCoroutine(FadeOutSemesterLabel());
    }
}
