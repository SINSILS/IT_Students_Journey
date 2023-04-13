using ClearSky;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public StudentController student;
    public PlatformManager platformManager;
    public EnemyManager enemyManager;
    public UpgradeManager upgradeManager;

    public TMP_Text semester;
    public TMP_Text score;
    int scoreValue = 0;
    int minLevel = 0;
    int maxLevel = 1;
    bool universityDone = false;

    GameObject upgradePanel;
    GameObject exitPanel;
    GameObject question1Panel;
    GameObject question2Panel;
    GameObject gameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        Resume(2);
        InvokeRepeating("updateScoreAndLevel", 0.05f, 0.05f);
        //InvokeRepeating("updateScoreAndLevel", 0.005f, 0.005f);
        setupPanels();
        ShowSemesterLabel("Semester " + maxLevel);
    }

    // Update is called once per frame
    void Update()
    {
        enemyManager.spawnEnemy(platformManager.getPlatforms(), minLevel, maxLevel);
        handleUpgradePanel();
        handleExitPanel();
        GameOver();
    }

    void updateScoreAndLevel()
    {
        scoreValue++;
        score.text = "Score : " + scoreValue;
        if (scoreValue % 1000 == 0 && maxLevel < 8)
        {
            maxLevel++;
            enemyManager.increaseEnemyCount();
            ShowSemesterLabel("Semester " + maxLevel);
        }
        else if (scoreValue % 1000 == 0 && maxLevel == 8 && !universityDone)
        {
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
            if (!exitPanel.activeSelf && !upgradePanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf)
            {
                Pause(1);
            }
            else if (exitPanel.activeSelf && !upgradePanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf)
            {
                Resume(1);
            }
        }
    }

    void handleUpgradePanel()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!upgradePanel.activeSelf && !exitPanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf)
            {
                Pause(0);
            }
            else if (upgradePanel.activeSelf && !exitPanel.activeSelf && !question1Panel.activeSelf && !question2Panel.activeSelf && !gameOverPanel.activeSelf)
            {
                Resume(0);
            }
        }
    }

    //0 - upgrades panel, 1 - exit panel, 2 - others
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
    }

    //0 - upgrades panel, 1 - exit panel, 2 - others
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
    }

    void GameOver()
    {
        if (student.getCurrentHP() <= 0)
        {
            Invoke("DelayGameOver", 1f);
        }
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
        semester.text = "Semester " + maxLevel;
        semester.enabled = true;
        StartCoroutine(FadeOutSemesterLabel());
    }
}
