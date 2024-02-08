using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LocationEffectConsequence
{
    public abstract void ApplyConsequence(int locationId, int amount = 0);
}
