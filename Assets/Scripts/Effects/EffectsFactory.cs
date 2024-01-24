using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsFactory
{
    private Dictionary<EffectValidators, EffectValidator> IfsDictionary = new Dictionary<EffectValidators, EffectValidator>
    {
        { EffectValidators.Null, new NullValidator() }
    };
    private Dictionary<EffectTriggers, EffectTrigger> TriggersDictionary = new Dictionary<EffectTriggers, EffectTrigger>()
    {
          { EffectTriggers.Null, new NullTrigger() }

    };
    private Dictionary<EffectConsequences, EffectConsequence> ConsequencesDictionary = new Dictionary<EffectConsequences, EffectConsequence>()
    {
        { EffectConsequences.Null, new NullConsequence() }
    };

    public Effect CreateEffect(EffectTriggers trigger, 
                                EffectValidators effectIf, 
                                EffectConsequences consequence,
                                int amount = 0)
    {
        var effectIf2 = IfsDictionary.GetValueOrDefault(effectIf);
        var trigger2 = TriggersDictionary.GetValueOrDefault(trigger);
        var consequence2 = ConsequencesDictionary.GetValueOrDefault(consequence);
        return new Effect(trigger2, effectIf2, consequence2, amount);
    }
}
