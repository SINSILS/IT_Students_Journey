using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Enemy prefab
    public GameObject blueEnemyPrefab;
    public GameObject greenEnemyPrefab;
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

    // Update is called once per frame
    void Update()
    {

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

    //int = 2 3 4 - to find out which enemy is being spawned
    //1 - C# (blueEnemy)
    //3 - Python (greenEnemy)
    //4 - JavaScript (redEnemy)
    public void spawnEnemy(int sceneIndex, List<GameObject> platforms, int minLevel, int maxLevel)
    {
        //0 - on platform, 1 - on the ground
        int random = Random.Range(0, 2);
        //spawn on platform
        if (enemies.Count < maxEnemyCount && random == 0)
        {
            int randomPlatformIndex = Random.Range(0, platforms.Count);
            var tempPlatform = platforms[randomPlatformIndex].GetComponent<Platform>();
            // Check if there is already an enemy on the platform
            if (tempPlatform.transform.position.x > 23 && !tempPlatform.IsTaken)
            {
                float x = tempPlatform.transform.position.x - 0.5f;
                float y = tempPlatform.transform.position.y + 0.4f;
                // Instantiate a new enemy
                instantiateEnemy(sceneIndex, randomPlatformIndex, tempPlatform, x, y, minLevel, maxLevel);
            }
        }
        //spawn on the ground
        else if (enemies.Count < maxEnemyCount && random == 1 && sceneIndex != 3)
        {
            float x = Random.Range(25f, 45f);
            float y = -8.4f;
            instantiateEnemy(sceneIndex, -1, null, x, y, minLevel, maxLevel);
        }
        else
        {
            removeEnemy(sceneIndex, platforms);
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
            //Red enemy
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
                //Red enemy
            }
            if (enemy.transform.position.x <= -24f || enemy.transform.position.y <= -10f || tempEnemyComponent.isDead)
            {
                tempEnemy = enemy;
            }
        }
        if (tempEnemy != null)
        {
            enemies.Remove(tempEnemy);

            if (!tempEnemyComponent.platformIndex.Equals(null))
            {
                platforms[tempEnemyComponent.platformIndex].GetComponent<Platform>().IsTaken = false;
            }
            StartCoroutine(DestroyTempEnemy(tempEnemy));
        }
    }
}
