using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class EnemyHealth : UnitHealth
{
    [SerializeField] private int _currentHealth;
    public int CurrentHealth => _currentHealth;

    public void ResetHealth()
    {
        _currentHealth = EnemyManager.Instance.EnemyStats.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, EnemyManager.Instance.EnemyStats.MaxHealth);

        EnemyManager.Instance.EAttack.StartAttacks();

        if (_currentHealth <= 0)
        {
            EnemyManager.Instance.EAttack.CancelAttack();
            EnemyManager.Instance.EVisual.PlayAnimation(UnitVisual.AnimationTrigger.Dead);
            Debug.Log("Enemy death");

            GameManager.Instance.GameOver();
        }
        else
        {
            EnemyManager.Instance.EVisual.PlayAnimation(UnitVisual.AnimationTrigger.Hit);
        }
    }
    
    public override float GetHealthNormalized()
    {
        if (EnemyManager.Instance == null)
        {
            return 1;
        }

        return _currentHealth / (float)EnemyManager.Instance.EnemyStats.MaxHealth;
    }
}
