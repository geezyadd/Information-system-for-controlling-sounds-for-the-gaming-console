using System;
using UnityEngine;

public class AudioUpdator : MonoBehaviour
{
    public event Action OnUpdate;

    private void Update()
    {
        OnUpdate?.Invoke();
    }
}
