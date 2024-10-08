using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NaranjerosInputManager : MonoBehaviour
{
    public static NaranjerosInputManager instance;

    public bool hitButtonIsPressed { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _hitAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
        _hitAction = _playerInput.actions["Hit"];
    }

    private void Update()
    {
        hitButtonIsPressed = _hitAction.WasPressedThisFrame();
    }
}

