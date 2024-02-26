using System;
using UnityEngine;
using Zenject;
public class AudioEffectManager
{
    private AudioEffectTypeMapper _audioEffectTypeMapping;
    [Inject]
    public void Construct(AudioEffectTypeMapper effectMapper)
    {
        _audioEffectTypeMapping = effectMapper;
    }
    public void AddAudioEffect(GameObject audioSourceObject, AudioEffectUnityEngineType effectType)
    {
        AudioSource audioSource = audioSourceObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("GameObject does not have an AudioSource component!");
            return;
        }

        Type componentType = _audioEffectTypeMapping.GetTypeFromEnum(effectType); 

        if (componentType != null)
        {
            if (!audioSourceObject.GetComponent(componentType))
            {
                audioSourceObject.AddComponent(componentType);
            }
            else
            {
                Debug.LogError($"GameObject already has {componentType}!");
            }
        }
        else
        {
            Debug.LogError($"Invalid component type: {componentType}");
        }
    }
}
