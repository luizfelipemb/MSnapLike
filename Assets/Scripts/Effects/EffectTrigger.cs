using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class EffectTrigger
{
    public UnityEvent TriggerEffect;
    public void Triggered()
    {
        TriggerEffect.Invoke();
    }
}