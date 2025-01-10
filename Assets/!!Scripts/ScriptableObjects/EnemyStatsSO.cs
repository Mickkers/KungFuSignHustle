using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyStats")]
public class EnemyStatsSO : ScriptableObject
{
    public int MaxHealth;
    public int Damage;
    public float TimeToAttack;
    public GameObject EnemyVisualPrefab;
}
