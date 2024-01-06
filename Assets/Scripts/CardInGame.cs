using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardInGame
{
    public int id;
    public CardBase BaseCard;
    public int firstOwnerId;

    public static bool operator ==(CardInGame card, int id)
    {
        return (card.id == id);
    }
    public static bool operator !=(CardInGame card, int id)
    {
        return !(card.id==id);
    }
    public CardInGame(CardBase card)
    {
        this.BaseCard = card;
    }
}
