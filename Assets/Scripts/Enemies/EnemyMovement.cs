using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;

    [Header("Stats")]
    [SerializeField] EnemyStats stats;


    Rigidbody2D rb;
    Vector2 direction;

    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (target.position - transform.position).normalized;
        MoveToTarget();
    }

    void MoveToTarget()
    {
        rb.AddForce(direction, ForceMode2D.Force);
    }
}
