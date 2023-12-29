using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public int id;
    public DeckManager deck;
    public List<CardInGame> hand;

    public void StartPlayerStuff()
    {
        deck.InstantiateDeck();
        deck.AssignPlayerId(id);
    }

    public void DrawInitialHand()
    {
        hand.AddRange(deck.Draw(3));
    }
}
