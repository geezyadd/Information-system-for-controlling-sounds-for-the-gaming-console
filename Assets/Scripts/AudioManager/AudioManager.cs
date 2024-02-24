using Unity.VisualScripting;
using UnityEngine;
using Zenject;
public class AudioManager 
{
    private AudioType _audioType;
    private AudioEntity _entity;
    private GameObject _source;
    public AudioManager(AudioType audioType, GameObject audioSource, AudioHolder config, Transform parent = null) 
    {
        _audioType = audioType;
        _entity = audioSource.GetComponent<AudioEntity>();
        _source = _entity.InstantiateSourcePrefab(audioSource, parent);
        foreach (AudioConfig sound in config.AudioConfig()) 
        {
            if(sound.AudioId == _audioType) 
            {
                _source.GetComponent<AudioSource>().clip = sound.SoundClip;
            }
        }
    }

    public void SimplePlay() 
    {
        _entity.SimplePlay(_source.GetComponent<AudioSource>());
    }

    public void MacaqueExample() 
    {
        _entity.Macaque();
    }
}
