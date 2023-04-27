using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //To decide which enemies needs to be spawned
    int sceneIndex;

    //Enemy prefab
    [SerializeField] private GameObject blueEnemyPrefab;
    [SerializeField] private GameObject greenEnemyPrefab;
    [SerializeField] private GameObject redEnemyPrefab;
    private List<GameObject> enemies = new List<GameObject>();
    private int maxEnemyCount = 3;

    //Parent GameObjects
    private GameObject enemyParent;
    private GameObject enemyProjectileParent;

    // Start is called before the first frame update
    void Start()
    {
        enemyParent = new GameObject("Enemies");
        enemyProjectileParent = new GameObject("EnemyProjectiles");
    }

    public void setScenIndex(int index)
    {
        sceneIndex = index;
    }

    public void increaseEnemyCount()
    {
        maxEnemyCount++;
    }

    IEnumerator DestroyTempEnemy(GameObject tempEnemy)
    {
        yield return new WaitForSeconds(1f);
        Destroy(tempEnemy);
    }

    //int = 1 3 4 - to find out which enemy is being spawned
    //1 - C# (blueEnemy)
    //3 - Python (greenEnemy)
    //4 - JavaScript (redEnemy)
    public void spawnEnemy(List<GameObject> platforms, int minLevel, int maxLevel)
    {
        if (platforms.Count != 0)
        {
            //0 - on platform, 1 - on the ground
            int random = Random.Range(0, 2);
            //spawn on platform
            int randomPlatformIndex = Random.Range(0, platforms.Count);
            //Debug.Log("platforms count: " + platforms.Count + "   I chose random this one: " + randomPlatformIndex);
            var tempPlatform = platforms[randomPlatformIndex].GetComponent<Platform>();
            if (enemies.Count < maxEnemyCount && random == 0 && tempPlatform.transform.position.x > 23 && !tempPlatform.IsTaken)
            {
                //Debug.Log("instantiate on the platform");
                float x = tempPlatform.transform.position.x - 0.5f;
                float y = tempPlatform.transform.position.y + 0.4f;
                // Instantiate a new enemy
                instantiateEnemy(sceneIndex, randomPlatformIndex, tempPlatform, x, y, minLevel, maxLevel);
            }
            //spawn on the ground
            else if (enemies.Count < maxEnemyCount && random == 1 && sceneIndex != 3)
            {
                //Debug.Log("instantiate on the ground");
                float x = Random.Range(25f, 45f);
                float y = -8.4f;
                instantiateEnemy(sceneIndex, -1, null, x, y, minLevel, maxLevel);
            }
            else
            {
                //Debug.Log("remove");
                removeEnemy(sceneIndex, platforms);
            }
        }
    }

    void instantiateEnemy(int sceneIndex, int randomPlatformIndex, Platform tempPlatform, float x, float y, int minLevel, int maxLevel)
    {
        GameObject newEnemy = null;
        Enemy enemyComponent = null;
        if (sceneIndex == 1)
        {
            newEnemy = GameObject.Instantiate(blueEnemyPrefab, new Vector2(x, y), Quaternion.identity);
            enemyComponent = newEnemy.GetComponent<BlueEnemy>();
        }
        else if (sceneIndex == 3)
        {
            newEnemy = GameObject.Instantiate(greenEnemyPrefab, new Vector2(x, y), Quaternion.identity);
            enemyComponent = newEnemy.GetComponent<GreenEnemy>();
        }
        else
        {
            newEnemy = GameObject.Instantiate(redEnemyPrefab, new Vector2(x, y), Quaternion.identity);
            enemyComponent = newEnemy.GetComponent<RedEnemy>();
        }
        newEnemy.transform.SetParent(enemyParent.transform, false);
        newEnemy.transform.Rotate(0, 180, 0);
        enemyComponent.setRandomStats(minLevel, maxLevel);
        if (randomPlatformIndex != -1)
        {
            tempPlatform.IsTaken = true;
            enemyComponent.platformIndex = randomPlatformIndex;
        }
        enemies.Add(newEnemy);
    }

    void removeEnemy(int sceneIndex, List<GameObject> platforms)
    {
        GameObject tempEnemy = null;
        Enemy tempEnemyComponent = null;
        foreach (var enemy in enemies)
        {
            if (sceneIndex == 1)
            {
                tempEnemyComponent = enemy.GetComponent<BlueEnemy>();
            }
            else if (sceneIndex == 3)
            {
                tempEnemyComponent = enemy.GetComponent<GreenEnemy>();
            }
            else
            {
                tempEnemyComponent = enemy.GetComponent<RedEnemy>();
            }
            if (enemy.transform.position.x <= -24f || tempEnemyComponent.isDead)
            {
                tempEnemy = enemy;
                break;
            }
        }
        if (tempEnemy != null)
        {
            if (!tempEnemyComponent.platformIndex.Equals(null))
            {
                platforms[tempEnemyComponent.platformIndex].GetComponent<Platform>().IsTaken = false;
            }
            enemies.Remove(tempEnemy);
            StartCoroutine(DestroyTempEnemy(tempEnemy));
        }
    }
}
