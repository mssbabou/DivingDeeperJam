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
        StartCoroutine(nameof(DespawnTimer));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.up;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit something");
        collision.GetComponent<Health>().TakeDamage(damage);
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
