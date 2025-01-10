using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private LevelSO _fallbackLevel;

    [SerializeField] CurrentSignUI _currentSignUI;

    [SerializeField] VoidEventChannelSO _gameOverEventChannel;

    private bool _gameActive = false;
    public bool GameActive => _gameActive;

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
        _gameOverEventChannel.OnEventRaised -= GameOver;
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        SetUpBattle();
    }

    private void SetUpBattle()
    {
        if (LevelManager.Instance.CurrentLevel == null)
        {
            LevelManager.Instance.CurrentLevel = _fallbackLevel;
        }

        EnemyManager.Instance.SetupEnemy(LevelManager.Instance.CurrentLevel.EnemySO);
        SignGenerator.Instance.SetSignPool(LevelManager.Instance.CurrentLevel.Signs);

        Invoke(nameof(StartCountdown), 1f);
    }

    private void StartCountdown()
    {
        // TODO: Start countdown
        AudioClipPlayer.Instance.PlayAudioClip(AudioClipPlayer.AudioClips.Fight);
        _currentSignUI.StartCountdown(3);
    }

    public void BattleStartSequence()
    {
        SignGenerator.Instance.GenerateSign();

        CombatInputManager.Instance.EnableCombatInput();

        _gameActive = true;
        EnemyManager.Instance.EAttack.StartAttacks();
    }

    public void GameOver()
    {
        _gameOverEventChannel.RaiseEvent();


        if (EnemyManager.Instance.EHealth.CurrentHealth <= 0)
        {
            AudioClipPlayer.Instance.PlayAudioClip(AudioClipPlayer.AudioClips.Win);
            LevelManager.Instance.LevelCompleted();
            GameOverUI.Instance.ShowWin();
        }
        else
        {
            AudioClipPlayer.Instance.PlayAudioClip(AudioClipPlayer.AudioClips.Lose);
            GameOverUI.Instance.ShowLose();
        }
    }
}
