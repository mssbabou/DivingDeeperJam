using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats", order = 1)]
public class EnemyStats : ScriptableObject
{
    [Header("Type")]
    public EnemyType type;

    [Header("Defensive")]
    public float health;
    public float armor;

    [Header("Offensive")]
    public float damage;
    public float range;

    [Header("Mobility")]
    public float speed;
}

public enum EnemyType
{
    melee,
    ranged,
    suicide,
    tank
}
