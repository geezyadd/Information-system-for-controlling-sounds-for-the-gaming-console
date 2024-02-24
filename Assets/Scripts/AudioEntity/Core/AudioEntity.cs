using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEntity : MonoBehaviour
{
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

    public void SimplePlay(AudioSource audioSource)
    {
        audioSource.Play();
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
}
