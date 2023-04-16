using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public int CSharp = 1;
    public int Python = 3;
    public int TutorialScene = 2;

    public void learnCSharp()
    {
        SceneManager.LoadScene(CSharp);
    }

    public void learnPython()
    {
        SceneManager.LoadScene(Python);
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
