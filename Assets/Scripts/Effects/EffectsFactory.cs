using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsFactory
{
    private Dictionary<EffectTriggers, EffectTrigger> TriggersDictionary = new Dictionary<EffectTriggers, EffectTrigger>()
    {
          { EffectTriggers.Null, new NullTrigger() },
          { EffectTriggers.OnReveal, new OnReveal() }
    };
    private Dictionary<EffectValidators, EffectValidator> ValidatorDictionary = new Dictionary<EffectValidators, EffectValidator>
    {
        { EffectValidators.Null, new NullValidator() }
    };
    private Dictionary<EffectConsequences, EffectConsequence> ConsequencesDictionary = new Dictionary<EffectConsequences, EffectConsequence>()
    {
        { EffectConsequences.Null, new NullConsequence() },
        { EffectConsequences.IncreasePower, new IncreasePower() }
    };

    public Effect CreateEffect(int cardId,
                                EffectTriggers trigger, 
                                EffectValidators effectValidator, 
                                EffectConsequences consequence,
                                int amount = 0)
    {

        if (ValidatorDictionary.TryGetValue(effectValidator, out var effectVal))
        {
            // Key was found, and effectVal is set to the corresponding value
        }
        else
        {
            Debug.LogWarning($"effectValidator Key was not found!");
            effectVal = new NullValidator();
        }

        if (TriggersDictionary.TryGetValue(trigger, out var effectTrig))
        {
            // Key was found, and effectTrig is set to the corresponding value
        }
        else
        {
            Debug.LogWarning($"effectTrig Key was not found!");
            effectTrig = new NullTrigger();
        }

        if (ConsequencesDictionary.TryGetValue(consequence, out var effectConseq))
        {
            // Key was found, and effectConseq is set to the corresponding value
        }
        else
        {
            Debug.LogWarning($"effectConseq Key was not found!");
            effectConseq = new NullConsequence();
        }
        return new Effect(cardId,effectTrig, effectVal, effectConseq, amount);
    }
}
