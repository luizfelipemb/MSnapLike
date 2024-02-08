using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePower : CardEffectConsequence
{
    public override void ApplyConsequence(int cardId, int amount = 0)
    {
        Debug.Log($"Power Increased of card:{cardId} by {amount}");
        GameManager.Instance.board.IncreasePowerOfCard(cardId, amount);
    }

}
