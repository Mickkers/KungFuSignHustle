using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    private float _timeElapsed = 0;

    public float AttackChargeProgress => _timeElapsed / EnemyManager.Instance.EnemyStats.TimeToAttack;

    private Coroutine _attackCoroutine;

    public void StartAttacks()
    {
        CancelAttack();

        if (GameManager.Instance.GameActive)
        {
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }
    }

    public void CancelAttack()
    {
        if (_attackCoroutine != null)
        {
            StopCoroutine(_attackCoroutine);
            _attackCoroutine = null;
        }
    }

    private IEnumerator AttackCoroutine()
    {
        _timeElapsed = 0;

        float timeToAttack = EnemyManager.Instance.EnemyStats.TimeToAttack;

        if (LevelManager.Instance.CurrentDifficulty == LevelManager.LevelDifficulty.Master)
        {
            timeToAttack /= 2;
        }

        while (_timeElapsed < timeToAttack)
        {
            _timeElapsed += Time.deltaTime;
            yield return null;
        }
        TriggerAttack();
    }

    float _attackTime = 1.1f;
    float _attackConsumeTime => 0.2f * _attackTime;

    private void TriggerAttack()
    {
        if (!GameManager.Instance.GameActive)
        {
            return;
        }

        EnemyManager.Instance.EVisual.PlayAnimation(Random.Range(0, 2) == 0 ? UnitVisual.AnimationTrigger.AtkOne : UnitVisual.AnimationTrigger.AtkTwo);
        PlayerManager.Instance.PHealth.TakeDamage(EnemyManager.Instance.EnemyStats.Damage);

        LeanTween.value(_timeElapsed, 0, _attackConsumeTime)
        .setEase(LeanTweenType.easeInOutQuad)
        .setOnUpdate((float t) =>
        {
            _timeElapsed = t;
        });

        Invoke(nameof(StartAttacks), _attackTime);
    }
}
