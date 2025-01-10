using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [Header("Player Stats")]
    [SerializeField] private int _maxHealth = 100;
    public int MaxHealth => _maxHealth;
    [SerializeField] private int _damage = 10;
    public int Damage => _damage;

    [Header("Components")]
    [SerializeField] private PlayerHealth _pHealth;
    public PlayerHealth PHealth => _pHealth;

    [SerializeField] private PlayerAttack _pAttack;
    public PlayerAttack PAttack => _pAttack;

    [SerializeField] private UnitVisual _pVisual;
    public UnitVisual PVisual => _pVisual;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
