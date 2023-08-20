using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform target;

    Rigidbody2D rb;
    Vector2 direction;

    float speed;
    float range;
    EnemyType type;

    public void Init(float speed, float range, EnemyType type)
    {
        this.speed = speed;
        this.range = range;
        this.type = type;
    }

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
        if (Vector3.Distance(target.position, transform.position) > range)
            rb.AddForce(Time.deltaTime * speed * direction, ForceMode2D.Force);

        else if (rb.velocity.magnitude > 0.1f && type == EnemyType.ranged)
            rb.AddForce(Time.deltaTime * speed * -rb.velocity, ForceMode2D.Force);
    }
}
