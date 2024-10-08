using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    #region Params
    [Header("-------Menu Canvas-------")]
    [SerializeField] private GameObject _mainMenuCanvasGO;
    [SerializeField] private GameObject _settingsMenuCanvasGO;
    [SerializeField] private GameObject _startMenuCanvasGO;
    
    [Header("-------Audio-------")]
    [SerializeField] private AudioMixer _audioMixer;

    [Header("-------Menu Buttons-------")]
    // change this with play button when imlemented
    [SerializeField] private GameObject _mainMenuFirstButton;
    [SerializeField] private GameObject _settingsMenuFirstButton;   

    [Header("-------Player Select-------")]
    [SerializeField] private GameObject _playerSelectGO;

    #endregion

    private bool isPaused;

    private void Start()
    {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(_mainMenuFirstButton);    
    }

    private void Update()
    {
       if (InputManager.instance.menuIsOpen)
       {
           if (!isPaused)
           {
               PauseGame();
           }
           else
           {
               ResumeGame();
           }
       }
    }

    #region Pause/Unpause Methods

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        _audioMixer.SetFloat("LowpassCutoff_Freq", 500);
        OpenSett();
        
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        _audioMixer.SetFloat("LowpassCutoff_Freq", 22000);
        OpenMainMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
    

    #region Menu Methods

    private void OpenMainMenu() {
        _mainMenuCanvasGO.SetActive(true);
        _settingsMenuCanvasGO.SetActive(false);
        _startMenuCanvasGO.SetActive(true);

        _playerSelectGO.transform.position = new Vector3(-836.47f, -481.4387f, 0.0f);

        EventSystem.current.SetSelectedGameObject(_mainMenuFirstButton);
    }

    private void OpenSett() {
        _settingsMenuCanvasGO.SetActive(true);
        _startMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_settingsMenuFirstButton);
    }


    public void ClosedAllMenus() {
        _mainMenuCanvasGO.SetActive(false);
        _settingsMenuCanvasGO.SetActive(false);
        _startMenuCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    #endregion
}
