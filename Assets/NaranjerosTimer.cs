using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaranjerosTimer : MonoBehaviour
{
    public LevelLoader levelLoader;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        else
        {
            levelLoader.LoadNextLevel(1);
        }
    }
}
