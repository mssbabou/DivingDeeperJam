using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class WeaponArmController : MonoBehaviour
{
    [Header("Bullet spawning")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float damage;
    [SerializeField] float attackSpeed;
    [Space]

    [SerializeField] Transform playerArm;
    [SerializeField] Camera mainCamera;


    PlayerControlsInputAction playerControls;

    SpriteRenderer playerRenderer;
    SpriteRenderer armRenderer;
    PlayerInput playerInput;

    float attackCooldown = 0;

    void Awake()
    {
        playerRenderer = GetComponent<SpriteRenderer>();
        armRenderer = playerArm.gameObject.GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();

        playerControls = new PlayerControlsInputAction();
        playerControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate arm
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.value);
        Vector2 look = playerArm.InverseTransformPoint(mousePos);

        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;

        playerArm.Rotate(0, 0, angle);

        // Shoot bullet
        if (playerControls.Attacking.Shoot.IsPressed() && attackCooldown <= 0)
        {
            Vector2 bulletLook = spawnPoint.InverseTransformPoint(mousePos);
            float bulletAngle = Mathf.Atan2(bulletLook.y, bulletLook.x) * Mathf.Rad2Deg - 90;

            GameObject bullet = Instantiate(bulletPrefab,
                spawnPoint.position,
                Quaternion.Euler(0, 0, spawnPoint.eulerAngles.z + bulletAngle));

            bullet.GetComponent<Bullet>().SetDamage(damage);
            attackCooldown = 1 / attackSpeed;
        }
        else if (attackCooldown > 0)
            attackCooldown -= Time.deltaTime;
    }
}
