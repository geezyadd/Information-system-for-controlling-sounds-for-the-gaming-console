using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Zenject;
public class AudioManager 
{
    private AudioType _audioType;
    private AudioEntity _audioEntity;
    private GameObject _audioSourcePrefab;
    private GameObject _audioSourcePrefabCopy;
    private AudioSource _audioSource;
    private AudioHolder _audioConfig;
    private Transform _parentTransform;
    private bool _isAudioSourceInstantiated = false;

    public AudioManager(AudioType audioType, GameObject audioSource, AudioHolder config, bool isInstantiateOnCreate = true, Transform parent = null) 
    {
        _parentTransform = parent;
        _audioConfig = config;
        _audioType = audioType;
        _audioSourcePrefab = audioSource;
        _audioEntity = _audioSourcePrefab.GetComponent<AudioEntity>();
        if(isInstantiateOnCreate) 
        {
            InitializeAudioSource();
        }
    }
    public void DestroyAudioSourcePrefab() 
    {
        _audioEntity.DestroySourcePrefab(_audioSourcePrefabCopy);
        _isAudioSourceInstantiated = false;
    }
    public void InitializeAudioSource() 
    {
        if (!_isAudioSourceInstantiated) 
        {
            _audioSourcePrefabCopy = _audioEntity.InstantiateSourcePrefab(_audioSourcePrefab, _parentTransform);
            _audioSource = _audioSourcePrefabCopy.GetComponent<AudioSource>();
            foreach (AudioConfig sound in _audioConfig.AudioConfig())
            {
                if (sound.AudioId == _audioType)
                {
                    SetSounClip(sound.SoundClip);
                }
            }
            _isAudioSourceInstantiated = true;
        }
        else 
        {
            Debug.LogError("AudioSource is already initialized!");
        }
    }

    public void SimplePlay() 
    {
        _audioEntity.SimplePlay(_audioSourcePrefabCopy.GetComponent<AudioSource>());
    }

    public void MacaqueExample() 
    {
        _audioEntity.Macaque();
    }
    private void SetSounClip(AudioClip sound) 
    {
        if (sound != null)
        {
            _audioSource.clip = sound;
        }
        else
        {
            Debug.LogError("Sound in cofig is null!");
        }
    }

}
