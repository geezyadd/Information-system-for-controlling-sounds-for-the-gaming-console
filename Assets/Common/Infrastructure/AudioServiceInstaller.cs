using UnityEngine;
using Zenject;

public class AudioServiceInstaller : MonoInstaller
{
    public GameObject AudioSourcePrefab;
    public AudioHolder AudioHolderConfig;

    public override void InstallBindings()
    {
        Container.BindInstance(AudioSourcePrefab).AsTransient(); 
        Container.BindInstance(AudioHolderConfig).AsSingle(); 
        Container.Bind<AudioManager>().AsTransient();
        Container.Bind<AudioManagerFactory>().AsTransient();
        Container.Bind<AudioEffectManager>().AsTransient();
        Container.Bind<AudioEntity>().AsTransient();
        Container.Bind<AudioEffectTypeMapper>().AsTransient();
    }
}
