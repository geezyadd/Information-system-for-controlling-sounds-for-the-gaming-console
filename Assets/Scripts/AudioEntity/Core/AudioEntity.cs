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
    public void SimplePlay(AudioSource audioSource)
    {
        audioSource.Play();
    }
    public void Macaque() 
    {
        Debug.Log("Macaque is running");
    }
}
