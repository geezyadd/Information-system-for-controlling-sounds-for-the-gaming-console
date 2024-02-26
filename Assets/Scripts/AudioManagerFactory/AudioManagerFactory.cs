using System;
using UnityEngine;
using Zenject;

public class AudioManagerFactory : IFactory<AudioType, bool, Transform, AudioManager>
{
    private readonly DiContainer _container;
    private GameObject _audioSource;
    private AudioHolder _audioConfig;
    private AudioEffectManager _effectManager;
    [Inject]
    public void Construct(GameObject audioSource, AudioHolder audioConfig, AudioEffectManager effectManager)
    {
        _effectManager= effectManager;
        _audioSource = audioSource;
        _audioConfig = audioConfig;
    }
    public AudioManagerFactory(DiContainer container)
    {
        _container = container;
    }

    public AudioManager Create(AudioType audioType, bool isInstantiateOnCreate = true, Transform parent = null)
    {
        return _container.Instantiate<AudioManager>(new object[] { audioType, _effectManager, _audioSource, _audioConfig,isInstantiateOnCreate, parent });
    }
}