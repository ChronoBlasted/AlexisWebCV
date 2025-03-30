using BaseTemplate.Behaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioClip _menuMusic;


    public void Init()
    {
        InitDictionnary();

        PlayMusic(_menuMusic);
    }

    private void InitDictionnary()
    {

    }

    void PlayMusic(AudioClip audioClip)
    {
        if (_musicSource.clip == audioClip) return;
        _musicSource.clip = audioClip;
        _musicSource.Play();
    }
}

[Serializable]
public class AudioString
{
    public string AudioName;
    public List<AudioClip> AudioClip;
}
