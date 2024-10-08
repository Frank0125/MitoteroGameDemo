using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Transform transform;
    public float speed = 10;
    public Vector2 minMax;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(11.19f, 0.64f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float increment = -10;
        // if(Input.GetKey(KeyCode.A)){
        //     increment = -1;
        // }
        // if(Input.GetKey(KeyCode.D)){
        //     increment = 1;
        // }

        increment = increment * speed;
        float x = transform.position.x;
        x += increment * Time.deltaTime;
        transform.position = new Vector3(x, transform.position.y, 0);

        // transform.position = Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -2.85f)
        {
            // -0.45f
            transform.position = new Vector3(11.19f, transform.position.y, 0);
        }

        // if(transform.position.y > minMax.y){
        //     transform.position = new Vector3(0, 3, 0);
        // } else if (transform.position.y < minMax.x){
        //     transform.position = new Vector3(0, 0, 0);
        // }
    }
}

