using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(EnemyMovement))]
public class EnemyController : MonoBehaviour
{
    [Header("Type")]
    public EnemyType type;

    [Header("Defensive")]
    [SerializeField] float health;
    [SerializeField] float armor;

    [Header("Offensive")]
    [SerializeField] float damage;
    [SerializeField] float range;
    [SerializeField] float attackSpeed;

    [Header("Mobility")]
    [SerializeField] float speed;
    [SerializeField] Transform target;

    Health targetHealth;

    Health healthScript;
    EnemyMovement enemyMovement;


    float attackTimer = 0;

    void Awake()
    {
        targetHealth = target.gameObject.GetComponent<Health>();

        healthScript = GetComponent<Health>();
        enemyMovement = GetComponent<EnemyMovement>();

        healthScript.death += OnDie;
    }

    void Start()
    {
        healthScript.Init(health, armor);
        enemyMovement.Init(speed, range, type);
    }

    void Update()
    {
        if (attackTimer <= Mathf.Epsilon && Vector3.Distance(target.position, transform.position) <= range)
            Attack();

        else if (attackTimer > Mathf.Epsilon)
            attackTimer -= Time.deltaTime;
    }

    void Attack()
    {
        targetHealth.TakeDamage(damage);
        attackTimer = 1 / attackSpeed;
    }

    void OnDie()
    {
        Destroy(gameObject);
    }
}
