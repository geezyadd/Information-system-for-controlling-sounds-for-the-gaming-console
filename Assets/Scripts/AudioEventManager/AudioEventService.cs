using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Unity.VisualScripting.Member;

public class AudioEventService { 
    private List<AudioManager> _managers = new();
    private GameObject _player;
    private AudioUpdator _audioUpdator;
    [Inject]
    public void Construct(AudioUpdator audioUpdator)
    {
        _audioUpdator = audioUpdator;
    }
    public void AddAudioManager(AudioManager manager) { _managers.Add(manager); Debug.Log(_managers.Count); }
    public void RemoveAudioManager(AudioManager manager) { 
        _managers.Remove(manager);
    }

    public void SetPlayer(GameObject player) { _player = player; Debug.Log(_player.name); } 


    public void SoundRange(AudioSource source)
    {
        source.spatialBlend = 1f;
        _audioUpdator.OnUpdate += () => Set3DSoundForAudiosource(source); // нужно отписаться

    }
    public void SoundRangeDisable(AudioSource source)
    {
        source.spatialBlend = 1f;
        _audioUpdator.OnUpdate -= () => Set3DSoundForAudiosource(source); // нужно отписаться

    }

    private void Set3DSoundForAudiosource(AudioSource source)
    {
        if (source.isPlaying && _player != null)
        {
            float distance = Vector3.Distance(_player.transform.position, source.transform.position);
            float volume = 1f - Mathf.Clamp01(distance / source.maxDistance);
            volume = Mathf.Max(volume, 0);

            source.volume = volume;
        }
    }

    public void SetAudioEnviroment(AudioEnviromentType audioEnviromentType, AudioSource source, bool enable = true)
    {
        switch (audioEnviromentType)
        {
            case AudioEnviromentType.None:
                break;
            case AudioEnviromentType.ObjectSound:
                if (enable)
                {
                    SoundRange(source);
                }
                else
                {
                    SoundRangeDisable(source);
                }
                break;
            case AudioEnviromentType.BackgroundMusic:

                break;
            default:
                Debug.LogError("Unknown type!");
                break;
        }
    }


}
