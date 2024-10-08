using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclesSpawners;
    public GameObject[] obstacles;

    void Start()
    {
        SpawnObstacles();
    }

    public void SpawnObstacles()
    {
        foreach (GameObject obstacleSpawner in obstaclesSpawners)
        {
            int randomObstacle = Random.Range(0, obstacles.Length);
            Instantiate(obstacles[randomObstacle], obstacleSpawner.transform.position, obstacles[randomObstacle].transform.rotation);
        }
    }
}
