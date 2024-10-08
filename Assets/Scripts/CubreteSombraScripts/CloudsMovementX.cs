using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovementX : MonoBehaviour
{
    public LogicManager logicManager;

    public float moveSpeed = 3;
    public float deadZone = 13;

    void Start()
    {
        logicManager = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    void Update()
    {
        if (!logicManager.timesUp)
        {
            transform.position = transform.position + Vector3.right * moveSpeed * Time.deltaTime;
            if (transform.position.x > deadZone)
            {
                Destroy(gameObject);
            }
        }
    }

}
