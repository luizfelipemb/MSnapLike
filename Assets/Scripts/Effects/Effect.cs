using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Effect
{
    private EffectTrigger effectTrigger;
    private EffectValidator effectValidator;
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
        this.effectValidator = effectIf;
        this.effectConseq = effectConseq;
        this.amount = amount;
        effectTrigger.SetMyCardId(cardId);
        this.effectTrigger?.TriggerEffect?.AddListener(Apply);
    }

    private void Apply()
    {
        Debug.Log("Effect Apply!");
        if (effectValidator.Passed())
        {
            effectConseq.ApplyConsequence(cardId,amount);
        }
    }
}