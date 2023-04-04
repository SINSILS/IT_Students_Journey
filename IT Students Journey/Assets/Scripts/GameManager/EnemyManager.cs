using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Enemy prefab
    public GameObject blueEnemyPrefab;
    private List<GameObject> blueEnemies = new List<GameObject>();
    private int maxEnemyCount = 3;

    //Parent GameObjects
    private GameObject blueEnemyParent;

    // Start is called before the first frame update
    void Start()
    {
        blueEnemyParent = new GameObject("BlueEnemies");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void increaseEnemyCount()
    {
        maxEnemyCount++;
    }

    public void spawnEnemy(List<GameObject> platforms, int level)
    {
        //0 - on platform, 1 - on the ground
        int random = Random.Range(0, 2);
        if (blueEnemies.Count < maxEnemyCount && random == 0)
        {
            int randomPlatformIndex = Random.Range(0, platforms.Count);
            var tempPlatform = platforms[randomPlatformIndex].GetComponent<Platform>();
            // Check if there is already an enemy on the platform
            if (tempPlatform.transform.position.x > 23 && !tempPlatform.IsTaken)
            {
                float x = tempPlatform.transform.position.x;
                float y = tempPlatform.transform.position.y + 0.4f;
                // Create a new enemy
                var newEnemy = GameObject.Instantiate(blueEnemyPrefab, new Vector2(x, y), Quaternion.identity);
                tempPlatform.IsTaken = true;
                newEnemy.transform.SetParent(blueEnemyParent.transform, false);
                newEnemy.transform.Rotate(0, 180, 0);
                BlueEnemy enemyComponent = newEnemy.GetComponent<BlueEnemy>();
                enemyComponent.platformIndex = randomPlatformIndex;
                enemyComponent.setRandomStats(level);
                // Add the new enemy
                blueEnemies.Add(newEnemy);
            }
        }
        else if (blueEnemies.Count < maxEnemyCount && random == 1)
        {
            float x = Random.Range(25f, 45f);
            float y = -7f;
            var newEnemy = GameObject.Instantiate(blueEnemyPrefab, new Vector2(x, y), Quaternion.identity);
            newEnemy.transform.SetParent(blueEnemyParent.transform, false);
            newEnemy.transform.Rotate(0, 180, 0);
            BlueEnemy enemyComponent = newEnemy.GetComponent<BlueEnemy>();
            enemyComponent.setRandomStats(level);
            blueEnemies.Add(newEnemy);
        }
        else
        {
            GameObject tempEnemy = null;
            foreach (var enemy in blueEnemies)
            {
                if (enemy.transform.position.x <= -24f || enemy.transform.position.y <= -10f || enemy.GetComponent<BlueEnemy>().isDead)
                {
                    tempEnemy = enemy;
                }
            }
            if (tempEnemy != null)
            {
                blueEnemies.Remove(tempEnemy);
                Destroy(tempEnemy);
                BlueEnemy tempEnemyComponent = tempEnemy.GetComponent<BlueEnemy>();
                if (!tempEnemyComponent.platformIndex.Equals(null))
                {
                    platforms[tempEnemyComponent.platformIndex].GetComponent<Platform>().IsTaken = false;
                }
            }
        }
    }
}
