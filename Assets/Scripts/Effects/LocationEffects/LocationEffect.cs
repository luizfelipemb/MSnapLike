using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationEffect : Effect
{
    private EffectTrigger effectTrigger;
    private LocationEffectValidator effectValidator;
    private LocationEffectConsequence effectConseq;
    private int locationId;
    public LocationEffect(
        int locationId,
        EffectTrigger effectTrigger,
        LocationEffectValidator effectIf,
        LocationEffectConsequence effectConseq,
        int amount)
    {
        this.locationId = locationId;
        this.effectTrigger = effectTrigger;
        this.effectValidator = effectIf;
        this.effectConseq = effectConseq;
        this.conseqAmount = amount;
        effectTrigger.SetMyCardId(locationId);
        effectValidator.SetMyLocationId(locationId);
        this.effectTrigger?.TriggerEffect?.AddListener(Apply);
    }
    protected override void Apply()
    {
        if (effectValidator.Passed())
        {
            effectConseq.ApplyConsequence(locationId, conseqAmount);
        }
    }
}
