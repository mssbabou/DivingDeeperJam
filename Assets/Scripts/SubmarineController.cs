using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class SubmarineController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] float health;

    Health healthScript;

    void Awake()
    {
        healthScript = GetComponent<Health>();

        healthScript.death += OnDie;
    }

    // Start is called before the first frame update
    void Start()
    {
        healthScript.Init(health, 69);   
    }

    void OnDie()
    {
        Destroy(gameObject);
    }
}
