using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardEffect : Effect
{
    protected EffectTrigger effectTrigger;
    protected CardEffectValidator effectValidator;
    protected CardEffectConsequence effectConseq;
    private int cardId;
    public CardEffect(
        int cardId,
        EffectTrigger effectTrigger,
        CardEffectValidator effectValidator,
        CardEffectConsequence effectConseq, 
        int amount)
    {   
        this.cardId = cardId;
        this.effectTrigger = effectTrigger;
        this.effectValidator = effectValidator;
        this.effectConseq = effectConseq;
        this.conseqAmount = amount;
        effectTrigger.SetMyCardId(cardId);
        this.effectValidator.SetMyCardId(cardId);
        this.effectTrigger?.TriggerEffect?.AddListener(Apply);
    }

    protected override void Apply()
    {
        if (effectValidator.Passed())
        {
            effectConseq.ApplyConsequence(cardId,conseqAmount);
        }
    }
}