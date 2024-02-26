using System;
using System.ComponentModel;
using UnityEngine;
using Zenject;

public class AudioServiceTest : MonoBehaviour
{
    private AudioManager _audioManager;
    [SerializeField] private AudioType _audioType;
    [SerializeField] private KeyCode _keyCode;

    [Inject]
    public void Construct(AudioManagerFactory audioManagerFactory)
    {
        _audioManager = audioManagerFactory.Create(_audioType, false, transform);
    }

    void Update()
    {
        if(Input.GetKeyDown(_keyCode)) {
            _audioManager.InitializeAudioSource();
            _audioManager.MacaqueExample();
            _audioManager.SimplePlay();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _audioManager.DestroyAudioSourcePrefab();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _audioManager.AddAudioEffect(AudioEffectUnityEngineType.AudioChorusFilter);
        }
        if (Input.GetKeyDown(KeyCode.Z)) 
        {
            UnityEngine.Component component;
            bool isTrue = _audioManager.GetAudioEffect(AudioEffectUnityEngineType.AudioChorusFilter, out component);
            if (isTrue)
            {
                Debug.Log(component.ToString());
                isTrue = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            AudioSource source;
            bool isTrue = _audioManager.GetAudioSource(out source);
            if (isTrue)
            {
                source.mute = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            AudioSource source;
            bool isTrue = _audioManager.GetAudioSource(out source);
            if (isTrue)
            {
                source.mute = false;
            }
        }
    }
}
