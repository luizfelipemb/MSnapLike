using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class DeckManager
{
    [SerializeField] private Deck cardsToBeAssigned;
    public List<CardInGame> DeckInGame = new List<CardInGame>();

    public void InstantiateDeck()
    {
        foreach (CardBase card in cardsToBeAssigned.cards)
        {
            DeckInGame.Add(new CardInGame(card));
        }
    }
    public List<CardInGame> Draw(int howManyCards)
    {
        if (DeckInGame.Count < howManyCards)
            howManyCards = DeckInGame.Count;
        List<CardInGame> cardsToDraw = new List<CardInGame>();
        for (int i = howManyCards-1; i>=0; i--)
        {
            cardsToDraw.Add(DeckInGame[i]);
            DeckInGame.RemoveAt(i);
        }
        return cardsToDraw;
    }
    public void AssignPlayerId(int id)
    {
        foreach(var card in DeckInGame)
        {
             card.firstOwnerId = id;
        }
    }
}
