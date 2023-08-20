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
        if (Vector3.Distance(target.position, transform.position) > stats.range)
            rb.AddForce(Time.deltaTime * stats.speed * direction, ForceMode2D.Force);

        //else if (rb.velocity.magnitude > 0.1f)
        //    rb.AddForce(Time.deltaTime * stats.speed * -rb.velocity, ForceMode2D.Force);
    }
}
