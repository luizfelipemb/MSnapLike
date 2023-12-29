using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardInGame
{
    public CardBase BaseCard;
    public int firstOwnerId;

    public CardInGame(CardBase card)
    {
        this.BaseCard = card;
    }
}
