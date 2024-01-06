using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LocationTile
{
    public CardBase[] cards = new NullCard[4];

    public bool HasSpace()
    {
        foreach (var card in cards)
        {
            if(card != new NullCard())
            {
                return false;
            }
        }
        return true;
    }
}
