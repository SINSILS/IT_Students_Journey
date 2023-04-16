using UnityEngine;
using UnityEngine.SceneManagement;

public class startGameButton : MonoBehaviour
{
    public int StartScena;

    public void StartGame()
    {
        SceneManager.LoadScene(StartScena);
    }
}
