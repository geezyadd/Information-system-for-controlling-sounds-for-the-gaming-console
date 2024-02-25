using UnityEngine;
using Zenject;
public class AudioEffectManager 
{
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
}
