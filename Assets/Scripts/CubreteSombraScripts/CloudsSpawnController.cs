using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawnController : MonoBehaviour
{
    public LogicManager logicManager;
    public CloudsMovementX[] clouds;
    public float spawnRate = 5;
    private float timer = 0;
    public float heightOffset = 2;

    // Start is called before the first frame update
    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();

        spawnCloud();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logicManager.timesUp)
        {
            if (timer < spawnRate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                spawnCloud();
                timer = 0;
                spawnRate = Random.Range(1, 5);
            }
        }

    }

    void spawnCloud()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        int randomCloud = Random.Range(0, clouds.Length);

        Instantiate(clouds[randomCloud], new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
