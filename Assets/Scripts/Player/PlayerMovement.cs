using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float acceleration;
    [SerializeField] float turnAcceleration;

    PlayerInput playerInput;
    Rigidbody2D rb;

    float targetRotation;

    void Awake ()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Time.deltaTime * acceleration * playerInput.movementInput, ForceMode2D.Force);

        targetRotation = Quaternion.FromToRotation(transform.up, playerInput.movementInput).eulerAngles.z;
        targetRotation = Mathf.Repeat(targetRotation + 180, 360) - 180;
        
        rb.AddTorque(turnAcceleration * targetRotation * Time.deltaTime, ForceMode2D.Force);
    }
}
