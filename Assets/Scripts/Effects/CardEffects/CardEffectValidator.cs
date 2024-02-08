using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardEffectValidator : EffectValidator
{
    protected int myCardId = -1;
    public virtual void SetMyCardId(int myCardId2)
    {
        myCardId = myCardId2;
    }
}