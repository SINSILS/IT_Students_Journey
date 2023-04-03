using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Platform prefab
    public PlatformManager platformManager;
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemyManager.spawnEnemy(platformManager.getPlatforms());
    }
}
