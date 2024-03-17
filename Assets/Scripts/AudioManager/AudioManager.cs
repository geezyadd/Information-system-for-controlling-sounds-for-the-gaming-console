using System;
using UnityEngine;
using Zenject;

public class AudioManager :IInitializable, IDisposable
{
    private AudioType _audioType;
    private AudioPrefabEntity _audioPrefabEntity;
    private GameObject _audioSourcePrefab;
    private GameObject _audioSourcePrefabCopy;
    private AudioSource _audioSource;
    private AudioHolder _audioConfig;
    private Transform _parentTransform;
    private bool _isAudioSourceInstantiated = false;
    private AudioEffectManager _effectManager;
    private AudioEventService _audioEventService;
    private AudioEnviromentType _audioEnviromentType;

    [Inject]
    public void Construct(AudioEventService audioEventService)
    {
        audioEventService.AddAudioManager(this);
        _audioEventService = audioEventService;
    }

    public AudioManager(AudioType audioType, AudioEffectManager effectManager, GameObject audioSource, AudioHolder audioConfig, AudioEnviromentType audioEnviromentType = AudioEnviromentType.None, bool isInstantiateOnCreate = true, Transform parent = null) 
    {
        _audioEnviromentType = audioEnviromentType;
        _effectManager = effectManager;
        _audioSourcePrefab = audioSource;
        _audioConfig = audioConfig;
        _parentTransform = parent;
        _audioType = audioType;
        _audioPrefabEntity = _audioSourcePrefab.GetComponent<AudioPrefabEntity>();
        if(isInstantiateOnCreate) 
        {
            InitializeAudioSource();
        }
    }
    public void DestroyAudioSourcePrefab() 
    {
        if (_audioSourcePrefabCopy != null)
        {
            _audioPrefabEntity.DestroySourcePrefab(_audioSourcePrefabCopy);
            _isAudioSourceInstantiated = false;
        }
        else
        {
            Debug.LogError("AudioPrephab is not initialized!");
        }
    }
    public void InitializeAudioSource() 
    {
        if (!_isAudioSourceInstantiated) 
        {
            _audioSourcePrefabCopy = _audioPrefabEntity.InstantiateSourcePrefab(_audioSourcePrefab, _parentTransform);
            _audioSource = _audioSourcePrefabCopy.GetComponent<AudioSource>();
            foreach (AudioConfig sound in _audioConfig.AudioConfig())
            {
                if (sound.AudioId == _audioType)
                {
                    _audioPrefabEntity.SetSounClip(_audioSource, sound.SoundClip);
                }
            }
            _isAudioSourceInstantiated = true;
            SetAudioEnviroment(_audioSource);
        }
        else 
        {
            Debug.LogError("AudioSource is already initialized!");
        }
    }

    private void SetAudioEnviroment(AudioSource source, bool enable = true)
    {
        _audioEventService.SetAudioEnviroment(_audioEnviromentType, source, enable);
    }

    public bool GetAudioSource(out AudioSource source) 
    {
        if(_audioSource != null)
        {
            source = _audioSource;
            return true;
        }
        else 
        {
            Debug.LogError("AudioSource must be initialized!");
            source =  null;
            return false;
        }
    }

    public void SimplePlay() 
    {
        _audioPrefabEntity.SimplePlay(_audioSourcePrefabCopy.GetComponent<AudioSource>());
    }

    public void AddAudioEffect(AudioEffectUnityEngineType audioEffectType) 
    {
        if(_audioSourcePrefabCopy != null) 
        {
            _effectManager.AddAudioEffect(_audioSourcePrefabCopy, audioEffectType);
        }
        else 
        {
            Debug.LogError("AudioPrephab is not initialized!");
        }
    }
    public bool GetAudioEffect(AudioEffectUnityEngineType audioEffectType, out Component component)
    {
        if (_audioSourcePrefabCopy != null)
        {
            component = _effectManager.GetAudioEffect(_audioSourcePrefabCopy, audioEffectType);
            return component != null;
        }
        else
        {
            Debug.LogError("AudioPrephab is not initialized!");
            component = null;
            return false;
        }
    }

    public GameObject GetAudioSourcePrefab() { return _audioSourcePrefab; }

    public void MacaqueExample() 
    {
        _audioPrefabEntity.Macaque();
    }

    public void Initialize()
    {
    }

    public void Dispose()
    {
        SetAudioEnviroment(_audioSource, false);
    }
}
