using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Platform prefab
    public PlatformManager platformManager;
    public EnemyManager enemyManager;
    //public StudentController student;
    public TMP_Text score;
    int scoreValue = 0;
    int level = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateScoreAndLevel", 0.05f, 0.05f); // Call UpdateScore every 1 second
        //InvokeRepeating("updateScoreAndLevel", 0.005f, 0.005f); // Call UpdateScore every 1 second
    }

    // Update is called once per frame
    void Update()
    {
        enemyManager.spawnEnemy(platformManager.getPlatforms(), level);
        restartGame();
    }

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

}
