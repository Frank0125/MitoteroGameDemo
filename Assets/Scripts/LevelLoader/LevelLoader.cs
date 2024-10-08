using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Header("-------Loading Screen-------")]
    [SerializeField] private Animator _transition;
    [SerializeField] private float _transitionTime = 1f;


    public void LoadNextLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + levelIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        _transition.SetTrigger("Start");
        yield return new WaitForSeconds(_transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
