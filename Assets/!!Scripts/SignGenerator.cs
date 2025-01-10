using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SignGenerator : MonoBehaviour
{
    public static SignGenerator Instance { get; private set; }

    [SerializeField] private List<SignSO> _signPool;

    [SerializeField] private SignSO _currentSign = null;
    public SignSO CurrentSign => _currentSign;

    [SerializeField] CurrentSignUI _currentSignUI;

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

    public void SetSignPool(List<SignSO> signPool)
    {
        _signPool = signPool;
    }

    [SerializeField] List<SignSO> _signBagShuffle = new List<SignSO>();

    public void GenerateSign()
    {
        SignSO newSign;

        if (_signBagShuffle.Count == 0)
        {
            _signBagShuffle.AddRange(_signPool);
        }

        do
        {
            newSign = _signBagShuffle[Random.Range(0, _signBagShuffle.Count)];
            if (_currentSign == null)
            {
                _currentSignUI.InstantSetSignImage(newSign.SignSprite);
            }
        }
        while (newSign == _currentSign);

        _signBagShuffle.Remove(newSign);

        _currentSign = newSign;
        _currentSignUI.SetSignImage(newSign.SignSprite);
    }

    public void CheckAnswer(string answer)
    {
        if (_currentSign.SignKeyValue == answer)
        {
            AudioClipPlayer.Instance.PlayAudioClip(AudioClipPlayer.AudioClips.Correct);

            HintBoardUI.Instance.HideHint();

            PlayerManager.Instance.PAttack.AttackEnemy();
            GenerateSign();
        }
        else
        {

            AudioClipPlayer.Instance.PlayAudioClip(AudioClipPlayer.AudioClips.Incorrect);

            if (LevelManager.Instance.CurrentDifficulty == LevelManager.LevelDifficulty.Easy || LevelManager.Instance.CurrentDifficulty == LevelManager.LevelDifficulty.Medium)
            {
                HintBoardUI.Instance.ShowHint();
            }

            if (LevelManager.Instance.CurrentDifficulty == LevelManager.LevelDifficulty.Medium || LevelManager.Instance.CurrentDifficulty == LevelManager.LevelDifficulty.Hard || LevelManager.Instance.CurrentDifficulty == LevelManager.LevelDifficulty.Master)
            {
                InputLockout();
            }
        }

    }

    private float _inputLockoutTime = 1f;

    private void InputLockout()
    {
        CombatInputManager.Instance.DisableCombatInput();
        Invoke(nameof(EnableInput), _inputLockoutTime);
    }

    private void EnableInput()
    {
        CombatInputManager.Instance.EnableCombatInput();
    }
}
