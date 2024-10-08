using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Sources ----------")]
    [SerializeField] private  AudioSource _musicSource;
    [SerializeField] private AudioSource _SFXSource;

    [Header("--------- Audio Clips ----------")]
    [SerializeField] private AudioClip _backgroundMusic;

    private void Start()
    {
        _musicSource.clip = _backgroundMusic;
        _musicSource.Play();
    }

    // This function will be called from other scripts to play SFX
    public void PlaySFX(AudioClip clip)
    {
        _SFXSource.clip = clip;
        _SFXSource.Play();
    }
}
