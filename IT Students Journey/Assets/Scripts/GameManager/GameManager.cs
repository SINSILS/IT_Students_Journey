using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Platform prefab
    public GameObject platformPrefab;
    private List<GameObject> platforms = new List<GameObject>();
    private float platformStartPointX = 20f;
    private float platformEndPointX;
    private float[] yValues = { -3.5f, 0f, 4f };
    private int lastPlatformLevel = 0;

    //Enemy prefab
    public GameObject blueEnemyPrefab;
    private List<GameObject> blueEnemies = new List<GameObject>();
    private int maxEnemyCount = 3;

    //Parent GameObjects
    private GameObject blueEnemyParent;
    private GameObject platformParent;

    // Start is called before the first frame update
    void Start()
    {
        platformParent = new GameObject("Platforms");
        blueEnemyParent = new GameObject("BlueEnemies");
    }

    // Update is called once per frame
    void Update()
    {
        spawnPlatform();
        spawnEnemy();
    }

    void spawnPlatform()
    {
        // Check if there are less than 10 platforms
        if (platforms.Count < 10)
        {
            // Generate a random position for the platform
            platformStartPointX = platformStartPointX + Random.Range(7f, 15f);
            float x = platformStartPointX;
            float y = yValues[lastPlatformLevel];
            if (lastPlatformLevel == 0)
            {
                int temp = Random.Range(0, 2);
                y = yValues[temp];
                lastPlatformLevel = temp;
            }
            else if (lastPlatformLevel == 1)
            {
                int temp = Random.Range(0, 3);
                y = yValues[temp];
                lastPlatformLevel = temp;
            }
            else
            {
                int temp = Random.Range(0, 2);
                y = yValues[temp];
                lastPlatformLevel = temp;
            }

            // Create a new platform at the generated position
            var platform = GameObject.Instantiate(platformPrefab, new Vector2(x, y), Quaternion.identity);
            platform.transform.SetParent(platformParent.transform, false);
            // Add the new platform to the list of platforms
            platforms.Add(platform);

            //Save last platform's X
            platformEndPointX = x;
        }
        else
        {
            foreach (var platform in platforms)
            {
                if (platform.transform.position.x <= -24f)
                {
                    // Generate a new position for the platform
                    float x = platformEndPointX - 42;
                    float y = yValues[lastPlatformLevel];
                    if (lastPlatformLevel == 0)
                    {
                        int temp = Random.Range(0, 2);
                        y = yValues[temp];
                        lastPlatformLevel = temp;
                    }
                    else if (lastPlatformLevel == 1)
                    {
                        int temp = Random.Range(0, 3);
                        y = yValues[temp];
                        lastPlatformLevel = temp;
                    }
                    else
                    {
                        int temp = Random.Range(0, 2);
                        y = yValues[temp];
                        lastPlatformLevel = temp;
                    }
                    // Move the existing platform to the new position
                    platform.transform.position = new Vector2(x, y);
                }
            }
        }
    }

    void spawnEnemy()
    {
        if (blueEnemies.Count < maxEnemyCount)
        {
            int randomPlatformIndex = Random.Range(0, platforms.Count);
            var tempPlatform = platforms[randomPlatformIndex].GetComponent<Platform>();
            // Check if there is already an enemy on the platform
            if (tempPlatform.transform.position.x > 23 && !tempPlatform.IsTaken)
            {
                float x = tempPlatform.transform.position.x;
                float y = tempPlatform.transform.position.y + 2f;
                // Create a new enemy
                var blueEnemy = GameObject.Instantiate(blueEnemyPrefab, new Vector2(x, y), Quaternion.identity);
                tempPlatform.IsTaken = true;
                blueEnemy.transform.SetParent(blueEnemyParent.transform, false);
                blueEnemy.transform.Rotate(0, 180, 0);
                blueEnemy.GetComponent<BlueEnemy>().platformIndex = randomPlatformIndex;
                // Add the new enemy
                blueEnemies.Add(blueEnemy);
            }
        }
        else
        {
            GameObject tempEnemy = null;
            foreach (var enemy in blueEnemies)
            {
                if (enemy.transform.position.x <= -24f || enemy.transform.position.y <= -10f)
                {
                    tempEnemy = enemy;
                }
            }
            if (tempEnemy != null)
            {
                blueEnemies.Remove(tempEnemy);
                Destroy(tempEnemy);
                platforms[tempEnemy.GetComponent<BlueEnemy>().platformIndex].GetComponent<Platform>().IsTaken = false;
            }
        }
    }
}
