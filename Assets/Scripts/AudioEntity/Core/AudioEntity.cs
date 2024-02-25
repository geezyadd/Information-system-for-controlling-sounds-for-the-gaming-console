using UnityEngine;
using Zenject;

public class AudioEntity : MonoBehaviour, IInitializable
{
    private AudioEffectManager _effectManager;
    [Inject]
    public void Construct(AudioEffectManager effectManager)
    {
        _effectManager = effectManager;
    }
    public GameObject InstantiateSourcePrefab(GameObject prefab, Transform parent = null)
    {
        if (parent != null)
        {
            return Instantiate(prefab, parent);
        }
        else
        {
            return Instantiate(prefab);
        }
    }

    public void DestroySourcePrefab(GameObject prefab)
    {
        Destroy(prefab);
    }
    public void AddAudioEffect(GameObject audioSourceObject, AudioEffectType effectType)
    {
        AudioSource audioSource = audioSourceObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("GameObject does not have an AudioSource component!");
            return;
        }

        switch (effectType)
        {
            case AudioEffectType.Chorus:
                if (!audioSourceObject.GetComponent<AudioChorusFilter>())
                {
                    audioSourceObject.AddComponent<AudioChorusFilter>();
                }
                else
                {
                    Debug.LogError($"GameObject already has {effectType}!");
                }
                break;
            case AudioEffectType.Distortion:
                if (!audioSourceObject.GetComponent<AudioDistortionFilter>())
                {
                    audioSourceObject.AddComponent<AudioDistortionFilter>();
                }
                else
                {
                    Debug.LogError($"GameObject already has {effectType}!");
                }
                break;
            case AudioEffectType.Echo:
                if (!audioSourceObject.GetComponent<AudioEchoFilter>())
                {
                    audioSourceObject.AddComponent<AudioEchoFilter>();
                }
                else
                {
                    Debug.LogError($"GameObject already has {effectType}!");
                }
                break;
            case AudioEffectType.HighPassFilter:
                if (!audioSourceObject.GetComponent<AudioHighPassFilter>())
                {
                    audioSourceObject.AddComponent<AudioHighPassFilter>();
                }
                else
                {
                    Debug.LogError($"GameObject already has {effectType}!");
                }
                break;
            case AudioEffectType.LowPassFilter:
                if (!audioSourceObject.GetComponent<AudioLowPassFilter>())
                {
                    audioSourceObject.AddComponent<AudioLowPassFilter>();
                }
                else
                {
                    Debug.LogError($"GameObject already has {effectType}!");
                }
                break;
            case AudioEffectType.Reverb:
                if (!audioSourceObject.GetComponent<AudioReverbFilter>())
                {
                    audioSourceObject.AddComponent<AudioReverbFilter>();
                }
                else
                {
                    Debug.LogError($"GameObject already has {effectType}!");
                }
                break;
            case AudioEffectType.ReverbZone:
                if (!audioSourceObject.GetComponent<AudioReverbZone>())
                {
                    audioSourceObject.AddComponent<AudioReverbZone>();
                }
                else
                {
                    Debug.LogError($"GameObject already has {effectType}!");
                }
                break;
            case AudioEffectType.Listener:
                if (!audioSourceObject.GetComponent<AudioListener>())
                {
                    audioSourceObject.AddComponent<AudioListener>();
                }
                else
                {
                    Debug.LogError($"GameObject already has {effectType}!");
                }
                break;
            default:
                Debug.LogWarning("Unsupported audio effect type.");
                break;
        }
    }

   //public void AddAudioEffect(GameObject prefab, AudioEffectType audioEffectType) 
   //{
   //    _effectManager.AddAudioEffect(prefab, audioEffectType);
   //}

    /// <summary>
    ///  Code to change AudioSource!
    /// </summary>
    
    public void SimplePlay(AudioSource audioSource)
    {
        audioSource.Play();
    }
    public void SetSounClip(AudioSource audioSource, AudioClip sound)
    {
        if (sound != null)
        {
            audioSource.clip = sound;
        }
        else
        {
            Debug.LogError("Sound is null!");
        }
    }

    public void SetMute(AudioSource audioSource, bool value) 
    {
        audioSource.mute = value;
    }

    public void SetBypassEffect(AudioSource audioSource, bool value)
    {
        audioSource.bypassEffects = value;
    }

    public void SetBypassListenerEffect(AudioSource audioSource, bool value)
    {
        audioSource.bypassListenerEffects = value;
    }

    public void SetBypassReverbZones(AudioSource audioSource, bool value)
    {
        audioSource.bypassReverbZones = value;
    }

    public void SetPlayOnAwake(AudioSource audioSource, bool value)
    {
        audioSource.playOnAwake = value;
    }

    public void SetLoop(AudioSource audioSource, bool value)
    {
        audioSource.loop = value;
    }

    public void SetPriority(AudioSource audioSource, int value)
    {
        if(value <= 0) 
        {
            Debug.LogError("Priority can't be <0!");
            return;
        }
        else if(value >= 255) 
        {
            Debug.LogError("Priority can't be >0!");
            return;
        }
        else 
        {
            audioSource.priority = value;
        }
    }

    public void SetSpatialBlend(AudioSource audioSource, float value)
    {
        if (value < 0f || value > 1f)
        {
            Debug.LogError("SpatialBlend value should be between 0 and 1.");
            return;
        }
        audioSource.spatialBlend = value;
    }

    public void SetReverbZoneMix(AudioSource audioSource, float value)
    {
        if (value < 0f || value > 1.1f)
        {
            Debug.LogError("ReverbZoneMix value should be between 0 and 1.1.");
            return;
        }
        audioSource.reverbZoneMix = value;
    }

    public void SetDopplerLevel(AudioSource audioSource, float value)
    {
        if (value < 0f || value > 5f)
        {
            Debug.LogError("DopplerLevel value should be between 0 and 5.");
            return;
        }
        audioSource.dopplerLevel = value;
    }

    public void SetSpread(AudioSource audioSource, float value)
    {
        if (value < 0f || value > 360f)
        {
            Debug.LogError("Spread value should be between 0 and 360.");
            return;
        }
        audioSource.spread = value;
    }

    public void SetVolume(AudioSource audioSource, float value)
    {
        if (value < 0f || value > 1f)
        {
            Debug.LogError("Volume value should be between 0 and 1.");
            return;
        }
        audioSource.volume = value;
    }

    public void SetMinDistance(AudioSource audioSource, float value)
    {
        if (value < 0f)
        {
            Debug.LogError("MinDistance value should be greater than or equal to 0.");
            return;
        }
        audioSource.minDistance = value;
    }

    public void SetMaxDistance(AudioSource audioSource, float value)
    {
        if (value < 0f)
        {
            Debug.LogError("MaxDistance value should be greater than or equal to 0.");
            return;
        }
        audioSource.maxDistance = value;
    }

    public void Macaque() 
    {
        Debug.Log("Macaque is running");
    }

    public void Initialize(){}
}
