using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static List<Transform> spawnPoints = new List<Transform>();
    public GameObject enemyPrefab, enemyContainer;
    public float enemyBurstCount = 3, spawnTime = 1;

    Transform oldlocation;

    Transform location;
    float updateTime = 1;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
            spawnPoints.Add(child);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > updateTime)
        {
            updateTime = Time.time + spawnTime;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        if (enemyContainer.transform.childCount < enemyBurstCount)
        {
            location = spawnPoints[Random.Range(0, transform.childCount)];

            while(location == oldlocation)
                location = spawnPoints[Random.Range(0, transform.childCount)];

            oldlocation = location;

            var enemyInstance = Instantiate(enemyPrefab, location.position, location.rotation);
            enemyInstance.transform.SetParent(enemyContainer.transform);
        }
    }
}
