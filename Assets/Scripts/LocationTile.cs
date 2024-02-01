using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class LocationTile
{
    public List<CardInGame> cards { get; private set; }

    public LocationTile()
    {
        cards = new List<CardInGame>(4);
    }
    public CardInGame GetCard(int id)
    {
        return cards.Find(card => card.id == id);
    }
    public bool HasCardById(int id)
    {
        return cards.Exists(card => card.id == id);
            
    }
    public bool HasCardByBaseCost(int cost)
    {
        return cards.Exists(card => card.baseCard.cost == cost);

    }
    public bool HasSpace()
    {
        return cards.Count != 4;
    }
    public void PlaceCard(CardInGame card)
    {
        if (HasSpace())
        {
            cards.Add(card);
        }
        else
            Debug.LogWarning("Tried placing card where already full");
    }
    public int GetPoints()
    {
        int points = 0;
        foreach (CardInGame card in cards)
        {
            points += card.currentPower;
        }
        return points;
    }
}
