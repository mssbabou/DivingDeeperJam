using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float acceleration;

    PlayerInput playerInput;
    Rigidbody2D rb;

    void Awake ()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("movement input: " + playerInput.movementInput);
        Debug.Log("Movement applied: " + Time.deltaTime * acceleration * playerInput.movementInput);

        MovePlayer(Time.deltaTime * acceleration * playerInput.movementInput);
    }

    void MovePlayer(Vector2 forceVector)
    {
        rb.AddForce(forceVector, ForceMode2D.Force);
    }
}
