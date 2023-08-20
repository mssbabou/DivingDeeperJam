using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public UnityAction death;

    float health;
    float armor;

    public void Init(float health, float armor)
    {
        this.health = health;
        this.armor = armor;

        Debug.Log("other.Health " + health);
        Debug.Log("this.Health " + this.health);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage taken: " + damage * (1 - armor / 100));
        Debug.Log("Health: " + health + "\nNew health" + (health - damage * (1 - armor / 100)));
        health -= damage * (1 - armor/100);

        if (health <= 0)
            death?.Invoke();
    }

    public void Heal(float healing)
    {
        health += healing;
    }
}
