using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnReveal : EffectTrigger
{
    public OnReveal()
    {
        EventsManager.UpdateHands.AddListener(base.Triggered);
    }
}
