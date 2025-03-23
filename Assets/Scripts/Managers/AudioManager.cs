using BaseTemplate.Behaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField] AudioSource _musicSource, _effectSource;
    [SerializeField] AudioClip _menuMusic;
    [SerializeField] List<AudioString> _effectList;

    Dictionary<string, List<AudioClip>> _effectDict = new Dictionary<string, List<AudioClip>>();
    List<AudioClip> _effectToPlay;

    public void Init()
    {
        InitDictionnary();

        PlayMusic(_menuMusic);
    }

    private void InitDictionnary()
    {
        foreach (AudioString camItem in _effectList)
        {
            _effectDict.Add(camItem.AudioName, camItem.AudioClip);
        }
    }

    public void PlaySound(string audioClip)
    {
        _effectDict.TryGetValue(audioClip, out _effectToPlay);

        if (_effectToPlay.Count > 1)
        {
            int indexSound = Random.Range(0, _effectToPlay.Count);
            _effectSource.PlayOneShot(_effectToPlay[indexSound]);
        }
        else
        {
            _effectSource.PlayOneShot(_effectToPlay[0]);
        }

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
