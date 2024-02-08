using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LocationEffectValidator
{
    protected int myLocationId = -1;
    public virtual void SetMyLocationId(int myCardId2)
    {
        myLocationId = myCardId2;
    }
    public abstract bool Passed();
}
