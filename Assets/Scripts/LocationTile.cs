using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocationTile
{
    private List<CardInGame> cards = new List<CardInGame>(4);

    public bool HasSpace()
    {
        return cards.Count != 4;
    }
}
