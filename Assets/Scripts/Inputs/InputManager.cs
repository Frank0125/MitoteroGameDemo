using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public bool menuIsOpen { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _menuOpenCloseAction;

    [SerializeField] private GameObject _logoImage;

    private bool _isPaused;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
        _menuOpenCloseAction = _playerInput.actions["SettingsMenu"];
    }
    
    private void Update()
    {
        menuIsOpen = _menuOpenCloseAction.WasPressedThisFrame();
        if (_logoImage.activeSelf)
        {
            _logoImage.SetActive(!menuIsOpen);
        } else
        {
            _logoImage.SetActive(menuIsOpen);
        }
    }
}

