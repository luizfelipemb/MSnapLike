using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public int id;
    public bool endedTurn;
    public int energy;
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
    public CardLocationTypes LocateCard(int cardId)
    {
        if (deck.ContainsCard(cardId))
            return CardLocationTypes.Deck;
        else if (Utils.ContainsById(cardId, hand))
            return CardLocationTypes.Hand;
        else return CardLocationTypes.Board;
    }
    public CardInGame GetCardByIdFromHand(int id)
    {
        return Utils.FindById(id, hand);
    }
    public CardInGame RemoveCardFromHand(int cardId)
    {
        CardInGame removedCard = hand.Find(card => card.id == cardId);
        hand.Remove(removedCard);
        return removedCard;
    }
}
