using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : UnitHealth
{
    [SerializeField] private int _currentHealth;

    private void Start()
    {
        _currentHealth = PlayerManager.Instance.MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, PlayerManager.Instance.MaxHealth);

        AudioClipPlayer.Instance.PlayAudioClip(AudioClipPlayer.AudioClips.Hit);

        if (_currentHealth <= 0)
        {
            Debug.Log("Player death");
            PlayerManager.Instance.PVisual.PlayAnimation(UnitVisual.AnimationTrigger.Dead);

            GameManager.Instance.GameOver();
        }
        else
        {
            PlayerManager.Instance.PVisual.PlayAnimation(UnitVisual.AnimationTrigger.Hit);
        }
    }

    public override float GetHealthNormalized()
    {
        if (PlayerManager.Instance == null)
        {
            return 1;
        }
        
        return _currentHealth / (float)PlayerManager.Instance.MaxHealth;
    }
}
