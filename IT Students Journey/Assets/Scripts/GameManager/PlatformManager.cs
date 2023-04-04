using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    //Platform prefab
    public GameObject platformPrefab;
    private List<GameObject> platforms = new List<GameObject>();
    private float platformStartPointX = 20f;
    private float platformEndPointX;
    private float[] yValues = { -3.5f, 0f, 4f };
    private int nextPlatformLevel = 0;

    //Parent GameObjects
    private GameObject platformParent;

    // Start is called before the first frame update
    void Start()
    {
        platformParent = new GameObject("Platforms");
    }

    // Update is called once per frame
    void Update()
    {
        spawnPlatform();
    }

    public List<GameObject> getPlatforms()
    {
        return platforms;
    }

    void spawnPlatform()
    {
        // Check if there are less than 10 platforms
        if (platforms.Count < 10)
        {
            // Generate a random position for the platform
            platformStartPointX = platformStartPointX + Random.Range(7f, 15f);
            float x = platformStartPointX;
            float y = yValues[nextPlatformLevel];
            if (nextPlatformLevel == 0)
            {
                y = yValues[nextPlatformLevel];
            }
            else if (nextPlatformLevel == 1)
            {
                y = yValues[nextPlatformLevel];
            }
            else
            {
                y = yValues[nextPlatformLevel];
            }
            nextPlatformLevel = Random.Range(0, 2);

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
                    float y = yValues[nextPlatformLevel];
                    if (nextPlatformLevel == 0)
                    {
                        int temp = Random.Range(0, 2);
                        y = yValues[temp];
                        nextPlatformLevel = temp;
                    }
                    else if (nextPlatformLevel == 1)
                    {
                        int temp = Random.Range(0, 3);
                        y = yValues[temp];
                        nextPlatformLevel = temp;
                    }
                    else
                    {
                        int temp = Random.Range(0, 2);
                        y = yValues[temp];
                        nextPlatformLevel = temp;
                    }
                    // Move the existing platform to the new position
                    platform.transform.position = new Vector2(x, y);
                }
            }
        }
    }
}
