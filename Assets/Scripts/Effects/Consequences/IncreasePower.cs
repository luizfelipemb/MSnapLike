using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePower : EffectConsequence
{
    public override void ApplyConsequence(int cardId, int amount = 0)
    {
        Debug.Log($"ApplyConsequences called");
        EffectsApplicator.IncreasePowerOfCard?.Invoke((cardId, amount));
    }
}
