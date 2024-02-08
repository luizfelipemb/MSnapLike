using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEffectsFactory : MonoBehaviour
{
    private Dictionary<EffectTriggers, Func<EffectTrigger>> TriggersDictionary = new Dictionary<EffectTriggers, Func<EffectTrigger>>()
    {
        { EffectTriggers.Null, () => new NullCardTrigger() },
        { EffectTriggers.OnReveal, () => new OnReveal() }
    };

    private Dictionary<LocationEffectValidators, Func<LocationEffectValidator>> ValidatorDictionary = new Dictionary<LocationEffectValidators, Func<LocationEffectValidator>>()
    {
        { LocationEffectValidators.Null, () => new NullLocationValidator() }
    };

    private Dictionary<LocationEffectConsequences, Func<LocationEffectConsequence>> ConsequencesDictionary = new Dictionary<LocationEffectConsequences, Func<LocationEffectConsequence>>()
    {
        { LocationEffectConsequences.Null, () => new NullLocationConsequence() }
        //{ LocationEffectConsequences.IncreasePower, () => new IncreasePower() }
    };

    public LocationEffect CreateEffect(int locationId,
                                EffectTriggers trigger,
                                LocationEffectValidators effectValidator,
                                LocationEffectConsequences consequence,
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

        LocationEffectValidator effectVal;
        if (ValidatorDictionary.TryGetValue(effectValidator, out var validatorFactory))
        {
            effectVal = validatorFactory();
        }
        else
        {
            Debug.LogWarning($"effectVal Key was not found!");
            effectVal = new NullLocationValidator();
        }

        LocationEffectConsequence effectConseq;
        if (ConsequencesDictionary.TryGetValue(consequence, out var consequenceFactory))
        {
            effectConseq = consequenceFactory();
        }
        else
        {
            Debug.LogWarning($"effectConseq Key was not found!");
            effectConseq = new NullLocationConsequence();
        }

        return new LocationEffect(locationId, effectTrig, effectVal, effectConseq, amount);
    }
}
