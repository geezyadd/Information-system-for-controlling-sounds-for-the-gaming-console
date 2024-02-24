using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_AudioConfig", menuName = "AudioConfig/DefaultAutoConfig", order = 1)]
public class AudioHolder : ScriptableObject
{
    [SerializeField] private List<AudioConfig> _audioConfig;
    public IEnumerable<AudioConfig> AudioConfig()
    {
        return _audioConfig;
    }
}
