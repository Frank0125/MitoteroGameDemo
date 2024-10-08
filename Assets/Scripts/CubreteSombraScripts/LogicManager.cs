using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
// using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public bool timesUp;
    public LevelLoader levelLoader;
    // public int playerScore;
    // public GameObject gameOverScreen;

    // public AudioSource src;
    // public AudioClip sfx_Point;

    // [SerializeField]
    // TextMeshProUGUI score;


    [SerializeField]
    TextMeshProUGUI timeRemainingText;

    // public Animator transition;
    // public float transitionTime = 1f;

    public void StartChangingScenene()
    {
        StartCoroutine(WaitMySceneChange(1));
    }

    IEnumerator WaitMySceneChange(int levelIndex)
    {
        yield return new WaitForSeconds(4);
        levelLoader.LoadNextLevel(1);
    }



    public void updateRemainingTime(string remainingTime)
    {
        timeRemainingText.text = remainingTime;
    }


}
