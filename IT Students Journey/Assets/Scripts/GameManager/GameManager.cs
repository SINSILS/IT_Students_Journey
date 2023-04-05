using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public StudentController student;
    public PlatformManager platformManager;
    public EnemyManager enemyManager;
    public UpgradeManager upgradeManager;

    public TMP_Text score;
    int scoreValue = 0;
    int level = 1;

    public static bool isPaused = false;
    GameObject upgradePanel;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateScoreAndLevel", 0.05f, 0.05f); // Call UpdateScore every 1 second
        //InvokeRepeating("updateScoreAndLevel", 0.005f, 0.005f); // Call UpdateScore every 1 second
        upgradePanel = GameObject.FindWithTag("UpgradePanel");
        upgradePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemyManager.spawnEnemy(platformManager.getPlatforms(), level);
        restartGame();
        PauseAndResume();
    }

    //void updateStatsFromStudent()
    //{

    //}

    void updateScoreAndLevel()
    {
        scoreValue++;
        score.text = "Score : " + scoreValue;
        if (scoreValue % 1000 == 0 && level < 8)
        {
            level++;
            enemyManager.increaseEnemyCount();
            Debug.Log("LEVEL " + level);
        }
    }

    void restartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void PauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
        upgradePanel.SetActive(true);
    }

    void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        upgradePanel.SetActive(false);
    }

}
