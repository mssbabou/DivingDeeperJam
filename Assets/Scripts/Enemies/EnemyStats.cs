using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStats : ScriptableObject
{
    [Header("Defensive")]
    public float health;
    public float armor;

    [Header("Offensive")]
    public float damage;
    public float range;

    [Header("Mobility")]
    public float speed;
}
