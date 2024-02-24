using System;
using UnityEngine;
using Zenject;

public class AudioManagerFactory : IFactory<AudioType, Transform, AudioManager>
{
    private readonly DiContainer _container;
    private GameObject _audioSource;
    private AudioHolder _audioConfig;
    [Inject]
    public void Construct(GameObject audioSource, AudioHolder audioConfig)
    {
        _audioSource = audioSource;
        _audioConfig = audioConfig;
    }
    public AudioManagerFactory(DiContainer container)
    {
        _container = container;
    }

    public AudioManager Create(AudioType audioType, Transform parent = null)
    {
        return _container.Instantiate<AudioManager>(new object[] { audioType, _audioSource, _audioConfig, parent });
    }
}