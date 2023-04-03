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
    private GameObject platformParent;

    // Start is called before the first frame update
    void Start()
    {
        blueEnemyParent = new GameObject("BlueEnemies");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnEnemy(List<GameObject> platforms)
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
                if (enemy.transform.position.x <= -24f || enemy.transform.position.y <= -10f || enemy.GetComponent<BlueEnemy>().isDead)
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
