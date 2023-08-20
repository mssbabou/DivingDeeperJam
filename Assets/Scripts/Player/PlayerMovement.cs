using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float maxSpeed;
    [SerializeField] float acceleration;
    [SerializeField] float deceleration;

    private Vector2 currentSpeed = Vector2.zero;

    PlayerInput playerInput;

    void Awake ()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("current speed" + currentSpeed);

        if (playerInput.movementInput.magnitude > 0)
            currentSpeed = Vector2.Lerp(currentSpeed, playerInput.movementInput * maxSpeed, acceleration * Time.deltaTime);

        else if (currentSpeed.magnitude > 0)
            currentSpeed = Vector2.Lerp(currentSpeed, Vector2.zero, acceleration * Time.deltaTime);

        MovePlayer();
    }

    void MovePlayer()
    {
        transform.position += (Vector3)currentSpeed * Time.deltaTime;
    }
}
