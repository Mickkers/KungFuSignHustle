using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AudioClipPlayer : MonoBehaviour
{
    public static AudioClipPlayer Instance { get; private set; }

    [SerializeField] AudioSource _fightAudioSource;
    [SerializeField] AudioSource _winAudioSource;
    [SerializeField] AudioSource _loseAudioSource;
    [SerializeField] AudioSource _hitAudioSource;
    [SerializeField] AudioSource _correctAudioSource;
    [SerializeField] AudioSource _incorrectAudioSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void PlayAudioClip(AudioClips audioClip)
    {
        AudioSource source = GetAudioSource(audioClip);
        
        if (source == null)
        {
            return;
        }

        if (audioClip == AudioClips.Hit)
        {
            source.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        }
        else
        {
            source.pitch = 1f;
        }
        source.Play();
    }

    private AudioSource GetAudioSource(AudioClips audioClip)
    {
        return audioClip switch
        {
            AudioClips.Fight => _fightAudioSource,
            AudioClips.Win => _winAudioSource,
            AudioClips.Lose => _loseAudioSource,
            AudioClips.Hit => _hitAudioSource,
            AudioClips.Correct => _correctAudioSource,
            AudioClips.Incorrect => _incorrectAudioSource,
            _ => null,
        };
    }

    public enum AudioClips
    {
        Fight,
        Win,
        Lose,
        Hit,
        Correct,
        Incorrect,
    }
}
