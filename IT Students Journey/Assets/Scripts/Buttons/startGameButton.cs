using UnityEngine;
using UnityEngine.SceneManagement;

public class startGameButton : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public int StartScena;

    public void StartGame()
    {
        SceneManager.LoadScene(StartScena);
    }
}
