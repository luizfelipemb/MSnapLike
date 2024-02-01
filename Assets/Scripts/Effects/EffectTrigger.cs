using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class EffectTrigger
{
    public int myCardId = -1;
    
    public UnityEvent TriggerEffect = new UnityEvent();
    public virtual void SetMyCardId(int myCardId2)
    {
        myCardId = myCardId2;
    }
    public void Triggered()
    {
        TriggerEffect?.Invoke();
    }
}