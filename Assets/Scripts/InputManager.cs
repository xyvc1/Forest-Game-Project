using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput inputSystem;

    public static Vector2 Movement;
    public static bool JumpWasPressed;
    public static bool JumpIsHeld;
    public static bool JumpWasReleased;
    public static bool RunIsHeld;

    private InputAction _moveAction;
    private InputAction _jumpAction;

    private void Awake()
    {
        inputSystem = GetComponent<PlayerInput>();

        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
    }
    public void JumpAction(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            Debug.Log("Recognizing jump");
            JumpWasPressed = true;
            JumpWasReleased = false;
        }
        else if (context.canceled)
        {
            JumpWasPressed = false;
            JumpWasReleased = true;
        }
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();

        JumpWasPressed = _jumpAction.WasPressedThisFrame();
        JumpIsHeld = _jumpAction.IsPressed();
        JumpWasReleased = _jumpAction.WasReleasedThisFrame();

      
    }
}