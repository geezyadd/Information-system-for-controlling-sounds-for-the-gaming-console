using UnityEngine;
using Zenject;

public class AudioPrefabEntity : MonoBehaviour, IInitializable
{
    private AudioEffectManager _effectManager;
    
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

    public void Macaque() 
    {
        Debug.Log("Macaque is running");
    }

    public void Initialize(){}
}
