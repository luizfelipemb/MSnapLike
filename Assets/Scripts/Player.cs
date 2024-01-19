using System.Collections.Generic;

[System.Serializable]
public class Player
{
    public int id;
    public bool endedTurn;
    public int energy;
    public DeckManager deck;
    public List<CardInGame> hand;
    private const int MaxCardsInHand = 7;

    public Player()
    {
        hand = new List<CardInGame>();
    }
    public void StartPlayerStuff()
    {
        deck.InstantiateDeck();
        deck.AssignPlayerId(id);
    }

    public void Draw(int numberOfCards = 1)
    {
        if(hand?.Count< MaxCardsInHand)
            hand?.AddRange(deck.Draw(numberOfCards));
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
        CardInGame removedCard = hand?.Find(card => card.id == cardId);
        if(removedCard != null)
            hand.Remove(removedCard);
        return removedCard;
    }
}
