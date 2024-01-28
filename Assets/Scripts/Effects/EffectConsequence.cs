using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EffectConsequence
{
    public abstract void ApplyConsequence(int cardId, int amount = 0);
}