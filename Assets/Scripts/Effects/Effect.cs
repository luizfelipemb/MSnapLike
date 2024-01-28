using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
    private EffectTrigger effectTrigger;
    private EffectValidator effectIf;
    private EffectConsequence effectConseq;
    private int amount;
    private int cardId;
    public Effect(
        int cardId,
        EffectTrigger effectTrigger, 
        EffectValidator effectIf, 
        EffectConsequence effectConseq, 
        int amount)
    {   
        this.cardId = cardId;
        this.effectTrigger = effectTrigger;
        this.effectIf = effectIf;
        this.effectConseq = effectConseq;
        this.amount = amount;
        this.effectTrigger?.TriggerEffect?.AddListener(Apply);
    }

    private void Apply()
    {
        Debug.Log("Effect Apply!");
        if (effectIf.PassedIf())
        {
            effectConseq.ApplyConsequence(cardId,amount);
        }
    }
}