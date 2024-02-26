using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffectTypeMapper 
{
    private Dictionary<AudioEffectUnityEngineType, Type> typeMap = new Dictionary<AudioEffectUnityEngineType, Type>()
    {
        { AudioEffectUnityEngineType.AudioChorusFilter, typeof(AudioChorusFilter) },
        { AudioEffectUnityEngineType.AudioDistortionFilter, typeof(AudioDistortionFilter) },
        { AudioEffectUnityEngineType.AudioEchoFilter, typeof(AudioEchoFilter) },
        { AudioEffectUnityEngineType.AudioHighPassFilter, typeof(AudioHighPassFilter) },
        { AudioEffectUnityEngineType.AudioLowPassFilter, typeof(AudioLowPassFilter) },
        { AudioEffectUnityEngineType.AudioReverbFilter, typeof(AudioReverbFilter) },
        { AudioEffectUnityEngineType.AudioReverbZone, typeof(AudioReverbZone) },
        { AudioEffectUnityEngineType.AudioListener, typeof(AudioListener) }
    };

    public Type GetTypeFromEnum(AudioEffectUnityEngineType effectType)
    {
        if (typeMap.TryGetValue(effectType, out Type type))
        {
            return type;
        }
        else
        {
            Debug.LogError("Type not found for enum value: " + effectType);
            return null;
        }
    }
}
