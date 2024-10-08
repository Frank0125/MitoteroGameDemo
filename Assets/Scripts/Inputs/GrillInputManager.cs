using UnityEngine;
using UnityEngine.InputSystem;


public class GrillInputManager : MonoBehaviour
{
    public static GrillInputManager instance;

    public bool RaisedSteak { get; private set; }

    private PlayerInput _playerInput;

    private InputAction _raiseSteak;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();
        _raiseSteak = _playerInput.actions["RaiseSteak"];
    }
    
    private void Update()
    {
        RaisedSteak = _raiseSteak.WasPressedThisFrame();
    }
}
