using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EffectTrigger
{
    public UnityEvent TriggerEffect = new UnityEvent();
    public void Triggered()
    {
        TriggerEffect?.Invoke();
    }
}