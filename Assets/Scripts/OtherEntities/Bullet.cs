using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float duration;

    float damage;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyBullet), duration);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.up;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit tag: " + collision.tag);
        if (collision.CompareTag("Submarine"))
            DestroyBullet();

        if (!collision.CompareTag("Enemy"))
            return;

        collision.GetComponent<Health>().TakeDamage(damage);
        DestroyBullet();
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
