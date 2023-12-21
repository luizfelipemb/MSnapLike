using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{
    public List<Card> cards;

    public List<Card> Draw(int howManyCards)
    {
        if (cards.Count < howManyCards)
            howManyCards = cards.Count;
        List<Card> cardsToDraw = new List<Card>();
        for (int i = howManyCards-1; i>=0; i--)
        {
            Debug.Log(i);
            cardsToDraw.Add(cards[i]);
            cards.RemoveAt(i);
        }
        return cardsToDraw;
    }
}
