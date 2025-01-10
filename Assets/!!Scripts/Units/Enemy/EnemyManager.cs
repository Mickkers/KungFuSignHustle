using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }

    [SerializeField] VoidEventChannelSO _gameOverEventChannel;

    [Header("Enemy Stats")]
    [SerializeField] private EnemyStatsSO _enemyStats;
    public EnemyStatsSO EnemyStats => _enemyStats;

    [Header("Components")]
    [SerializeField] private EnemyHealth _eHealth;
    public EnemyHealth EHealth => _eHealth;
    [SerializeField] private EnemyAttack _eAttack;
    public EnemyAttack EAttack => _eAttack;

    [SerializeField] private UnitVisual _eVisual;
    public UnitVisual EVisual => _eVisual;

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
        _gameOverEventChannel.OnEventRaised -= DisableEnemy;
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        _gameOverEventChannel.OnEventRaised += DisableEnemy;
    }

    private void DisableEnemy()
    {
        _eAttack.CancelAttack();
        
    }

    public void SetupEnemy(EnemyStatsSO enemyStats)
    {
        _enemyStats = enemyStats;

        GameObject enemyVisual = Instantiate(_enemyStats.EnemyVisualPrefab, transform);

        _eVisual = enemyVisual.GetComponent<UnitVisual>();
        
        _eHealth.ResetHealth();
    }
}
