using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int GameScene = 1;
    public int TutorialScene = 2;

    public void StartGame()
    {
        SceneManager.LoadScene(GameScene);
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene(TutorialScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
