using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffectsFactory
{
    private Dictionary<EffectTriggers, Func<EffectTrigger>> TriggersDictionary = new Dictionary<EffectTriggers, Func<EffectTrigger>>()
    {
        { EffectTriggers.Null, () => new NullCardTrigger() },
        { EffectTriggers.OnReveal, () => new OnReveal() }
    };

    private Dictionary<CardEffectValidators, Func<CardEffectValidator>> ValidatorDictionary = new Dictionary<CardEffectValidators, Func<CardEffectValidator>>()
    {
        { CardEffectValidators.Null, () => new NullCardValidator() }
    };

    private Dictionary<CardEffectConsequences, Func<CardEffectConsequence>> ConsequencesDictionary = new Dictionary<CardEffectConsequences, Func<CardEffectConsequence>>()
    {
        { CardEffectConsequences.Null, () => new NullCardConsequence() },
        { CardEffectConsequences.IncreasePower, () => new IncreasePower() }
    };

    public CardEffect CreateEffect(int cardId,
                                EffectTriggers trigger,
                                CardEffectValidators effectValidator,
                                CardEffectConsequences consequence,
                                int amount = 0)
    {
        EffectTrigger effectTrig;
        if (TriggersDictionary.TryGetValue(trigger, out var triggerFactory))
        {
            effectTrig = triggerFactory();
        }
        else
        {
            Debug.LogWarning($"effectTrig Key was not found!");
            effectTrig = new NullCardTrigger();
        }

        CardEffectValidator effectVal;
        if (ValidatorDictionary.TryGetValue(effectValidator, out var validatorFactory))
        {
            effectVal = validatorFactory();
        }
        else
        {
            Debug.LogWarning($"effectVal Key was not found!");
            effectVal = new NullCardValidator();
        }

        CardEffectConsequence effectConseq;
        if (ConsequencesDictionary.TryGetValue(consequence, out var consequenceFactory))
        {
            effectConseq = consequenceFactory();
        }
        else
        {
            Debug.LogWarning($"effectConseq Key was not found!");
            effectConseq = new NullCardConsequence();
        }

        return new CardEffect(cardId, effectTrig, effectVal, effectConseq, amount);
    }
}
