using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    private EffectTrigger effectTrigger;
    private EffectValidator effectIf;
    private EffectConsequence effectConseq;
    private int amount;
    public Effect(EffectTrigger effectTrigger, EffectValidator effectIf, EffectConsequence effectConseq, int amount)
    {
        this.effectTrigger = effectTrigger;
        this.effectIf = effectIf;
        this.effectConseq = effectConseq;
        this.amount = amount;
        this.effectTrigger?.TriggerEffect?.AddListener(Apply);
    }

    private void Apply()
    {
        if (effectIf.PassedIf())
        {
            effectConseq.ApplyConsequence(amount);
        }
    }
}