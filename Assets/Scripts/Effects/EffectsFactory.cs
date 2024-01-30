using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsFactory
{
    private Dictionary<EffectTriggers, Func<EffectTrigger>> TriggersDictionary = new Dictionary<EffectTriggers, Func<EffectTrigger>>()
    {
        { EffectTriggers.Null, () => new NullTrigger() },
        { EffectTriggers.OnReveal, () => new OnReveal() }
    };

    private Dictionary<EffectValidators, Func<EffectValidator>> ValidatorDictionary = new Dictionary<EffectValidators, Func<EffectValidator>>()
    {
        { EffectValidators.Null, () => new NullValidator() }
    };

    private Dictionary<EffectConsequences, Func<EffectConsequence>> ConsequencesDictionary = new Dictionary<EffectConsequences, Func<EffectConsequence>>()
    {
        { EffectConsequences.Null, () => new NullConsequence() },
        { EffectConsequences.IncreasePower, () => new IncreasePower() }
    };

    public Effect CreateEffect(int cardId,
                                EffectTriggers trigger,
                                EffectValidators effectValidator,
                                EffectConsequences consequence,
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
            effectTrig = new NullTrigger();
        }

        EffectValidator effectVal;
        if (ValidatorDictionary.TryGetValue(effectValidator, out var validatorFactory))
        {
            effectVal = validatorFactory();
        }
        else
        {
            Debug.LogWarning($"effectVal Key was not found!");
            effectVal = new NullValidator();
        }

        EffectConsequence effectConseq;
        if (ConsequencesDictionary.TryGetValue(consequence, out var consequenceFactory))
        {
            effectConseq = consequenceFactory();
        }
        else
        {
            Debug.LogWarning($"effectConseq Key was not found!");
            effectConseq = new NullConsequence();
        }

        return new Effect(cardId, effectTrig, effectVal, effectConseq, amount);
    }
}
