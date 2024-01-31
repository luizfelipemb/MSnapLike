using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnReveal : EffectTrigger
{
    public OnReveal()
    {
        EffectsApplicator.CardRevealed.AddListener(CheckIfThisPlayed);
    }
    private void CheckIfThisPlayed(int cardId)
    {
        if(cardId == myCardId)
        {
            base.Triggered();
            Debug.Log("OnReveal Happened!");
        }

    }
}