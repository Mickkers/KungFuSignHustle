using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] string _currentAnswerKey = string.Empty;
    public string CurrentAnswerKey => _currentAnswerKey;

    public void SetAnswerKey(string key)
    {
        _currentAnswerKey = key.ToUpper();
    }

    public void SubmitAnswer()
    {

        if (_currentAnswerKey == string.Empty)
        {
            return;
        }

        SignGenerator.Instance.CheckAnswer(_currentAnswerKey);

        _currentAnswerKey = string.Empty;
    }

    public void AttackEnemy()
    {
        EnemyManager.Instance.EHealth.TakeDamage(PlayerManager.Instance.Damage);
        PlayerManager.Instance.PVisual.PlayAnimation(UnitVisual.AnimationTrigger.AtkOne);
    }
}
