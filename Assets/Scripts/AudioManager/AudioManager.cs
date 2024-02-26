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
    private AudioEffectManager _effectManager;

   
    public AudioManager(AudioType audioType, AudioEffectManager effectManager, GameObject audioSource, AudioHolder audioConfig, bool isInstantiateOnCreate = true, Transform parent = null) 
    {
        _effectManager = effectManager;
        _audioSourcePrefab = audioSource;
        _audioConfig = audioConfig;
        _parentTransform = parent;
        _audioType = audioType;
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
                    _audioEntity.SetSounClip(_audioSource, sound.SoundClip);
                }
            }
            _isAudioSourceInstantiated = true;
            _audioEntity.SetAudioEffectManager(_effectManager);
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

    public void AddAudioEffect(AudioEffectType audioEffectType) 
    {
        if(_audioSourcePrefabCopy != null) 
        {
            _audioEntity.AddAudioEffect(_audioSourcePrefabCopy, audioEffectType);
        }
        else 
        {
            Debug.LogError("AudioPrephab is not initialized!");
        }
    }

    public void MacaqueExample() 
    {
        _audioEntity.Macaque();
    }
}
