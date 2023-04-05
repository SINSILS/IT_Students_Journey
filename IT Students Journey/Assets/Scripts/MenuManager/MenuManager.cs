using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int CSharp = 1;
    public int TutorialScene = 2;

    public void learnCSharp()
    {
        SceneManager.LoadScene(CSharp);
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
