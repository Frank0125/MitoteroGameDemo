using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrillController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of movement
    private float upperLimit = 0.5f;
    private bool movingUp = true;
    private float timeDT = 0f;

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        timeDT += Time.deltaTime;

        if(timeDT >= 2){

            if (movingUp) {
                // Move upwards
                if (transform.position.y < upperLimit) {
                    transform.position = new Vector3(transform.position.x, transform.position.y + step, transform.position.z);
                } else {
                    movingUp = false; // Switch to moving down
                }
            } else {
                // Move downwards
                if (transform.position.y > 0 ){
                    transform.position = new Vector3(transform.position.x, transform.position.y - step, transform.position.z);
                } else {
                    movingUp = true; // Switch to moving up
                    timeDT = 0;
                }
            }
        }
    }
}
