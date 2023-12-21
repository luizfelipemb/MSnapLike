using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public Deck deck;
    public List<Card> hand;

    public void DrawInitialHand()
    {
        hand.AddRange(deck.Draw(3));
    }
}
