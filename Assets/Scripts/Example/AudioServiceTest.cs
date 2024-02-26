using System;
using UnityEngine;
using Zenject;

public class AudioServiceTest : MonoBehaviour
{
    private AudioManager _audioManager;
    [SerializeField] private AudioType _audioType;
    [SerializeField] private KeyCode _keyCode;
    public Type type = typeof(AudioChorusFilter);

    [Inject]
    public void Construct(AudioManagerFactory audioManagerFactory)
    {
        _audioManager = audioManagerFactory.Create(_audioType, false, transform);
    }

    void Update()
    {
        Debug.Log(type);
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
    }
}
