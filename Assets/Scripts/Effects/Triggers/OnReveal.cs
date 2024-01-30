using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnReveal : EffectTrigger
{
    public OnReveal()
    {
        EffectsApplicator.CardRevealed.AddListener(CheckIfThisPlayed);
        Debug.Log($"OnReveal() myCardId: {myCardId}; base.myCardId:{ base.myCardId}");
    }
    public override void SetMyCardId(int myCardId2)
    {
        Debug.Log("effect OnReveal setmycardid to " + myCardId);
        myCardId = myCardId2;
    }
    private void CheckIfThisPlayed(int cardId)
    {
        Debug.Log($"CheckIfThisPlayed cardId:{cardId} == myCardId:{myCardId} ; base.myCardId:{base.myCardId}");
        if(cardId == myCardId)
        {
            base.Triggered();
            Debug.Log("OnReveal Happened!");
        }

    }
}