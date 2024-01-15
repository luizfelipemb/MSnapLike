using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocationTile
{
    public List<CardInGame> cards;

    LocationTile()
    {
        cards = new List<CardInGame>(4);
    }
    public bool HasSpace()
    {
        return cards.Count != 4;
    }
    public void PlaceCard(CardInGame card)
    {
        if (HasSpace())
            cards.Add(card);
        else
            Debug.LogWarning("Tried placing card where already full");
    }
}
