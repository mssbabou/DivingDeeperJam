using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(EnemyMovement))]
public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] EnemyStats stats;

    Health health;
    EnemyMovement enemyMovement;

    void Awake()
    {
        health = GetComponent<Health>();
        enemyMovement = GetComponent<EnemyMovement>();

        health.death += OnDie;
    }

    // Start is called before the first frame update
    void Start()
    {
        health.Init(stats.health, stats.armor);
        enemyMovement.Init(stats.speed, stats.range, stats.type);
    }

    void OnDie()
    {
        Destroy(gameObject);
    }
}
