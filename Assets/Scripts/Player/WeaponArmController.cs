using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class WeaponArmController : MonoBehaviour
{
    [SerializeField] Transform playerArm;
    [SerializeField] Camera mainCamera;


    SpriteRenderer playerRenderer;
    SpriteRenderer armRenderer;
    PlayerInput playerInput;

    void Awake()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        armRenderer = playerArm.gameObject.GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.value);
        Vector2 look = playerArm.InverseTransformPoint(mousePos);

        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        playerArm.Rotate(0, 0, angle);
    }

    bool IsLeftOfVector(Vector2 vector, Vector2 point)
    {
        Vector2 direction = point - vector;

        return -vector.x * direction.y + vector.y * direction.x < 0;
    }
}
