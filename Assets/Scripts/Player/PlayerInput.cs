using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerControlsInputAction playerControls;
    public Vector2 movementInput { get; private set; }

    void Awake ()
    {
        playerControls = new PlayerControlsInputAction();
    }

    void OnEnable ()
    {
        playerControls.Movement.Move.Enable();
    }

    void Update()
    {
        movementInput = playerControls.Movement.Move.ReadValue<Vector2>();
    }
}
