using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerAudioMapper : MonoBehaviour
{
    [Inject]
    public void Construct(AudioEventService audioEventService)
    {
        audioEventService.SetPlayer(gameObject);
    }
}
